using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Auth;
using FinancialControl.Domain.Business.Responses.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Interfaces;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IJwtBuilder _jwtBuilder;
        private readonly IAuthBusiness _authBusiness;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(ILogger<BaseController> logger,
            IJwtBuilder jwtBuilder,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IAuthBusiness authBusiness) : base(logger)
        {
            _jwtBuilder = jwtBuilder;
            _signInManager = signInManager;
            _userManager = userManager;
            _authBusiness = authBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signup")]
        [ProducesResponseType(typeof(SignupResponse), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Signup(SignupRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Signup)} - POST");

                var response = await _authBusiness.Validate(request);
                if (response.IsValid())
                {
                    var identityUser = new IdentityUser
                    {
                        Email = request.Email,
                        UserName = request.UserName,
                        EmailConfirmed = true
                    };
                    var result = await _userManager.CreateAsync(identityUser, request.Password);
                    var jwt = await _jwtBuilder
                        .WithEmail(identityUser.Email)
                        .WithJwtClaims()
                        .WithUserClaims()
                        .WithUserRoles()
                        .WithRefreshToken()
                        .BuildUserResponse();

                    return ResultOnSignup(result, jwt);
                }

                return ResultWhenAdding(response);
            }
            catch (Exception ex)
            {
                var message = "Error to signup";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        [ProducesResponseType(typeof(SigninResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Signin(SigninRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Signin)} - POST");

                var validationResponse = await _authBusiness.Validate(request);
                if (validationResponse.IsValid())
                {
                    var user = await _userManager.FindByNameAsync(request.UserName);
                    if (user is null)
                    {
                        return CustomBadRequest("Login e/ou senha está incorreto");
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, password: request.Password, false, true);

                    var userResponse = await _jwtBuilder
                        .WithEmail(user.Email)
                        .WithJwtClaims()
                        .WithUserClaims()
                        .WithUserRoles()
                        .WithRefreshToken()
                        .BuildUserResponse();

                    return ResultWhenSignIn(result, userResponse: userResponse, request: request);
                }

                return ResultWhenSignIn(validationResponse.GetValidationFailures());
            }
            catch (Exception ex)
            {
                var message = "Error to signin";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return CustomBadRequest("Invalid Refresh Token");
            }

            var token = await _jwtBuilder.ValidateRefreshToken(refreshToken);

            if (!token.IsValid)
            {
                CustomBadRequest("Expired Refresh Token");
            }

            var jwt = await _jwtBuilder
                                        .WithUserId(token.UserId)
                                        .WithJwtClaims()
                                        .WithUserClaims()
                                        .WithUserRoles()
                                        .WithRefreshToken()
                                        .BuildUserResponse();

            return ResultOnSignin(jwt);
        }
    }
}

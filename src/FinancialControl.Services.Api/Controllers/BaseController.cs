using FinancialControl.Domain.Business.Requests.Auth;
using FinancialControl.Domain.Business.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Jwt.Model;

namespace FinancialControl.Services.Api.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private const string GenericPropertyName = "Generic";
        protected readonly ILogger Logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
        }

        protected ObjectResult ResultWhenAdding(BaseResponse response)
        {
            if (response.IsValid())
            {
                Logger.LogInformation($"item added: {response}");
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return CustomBadRequest(response.GetValidationFailures());
        }

        protected ObjectResult ResultOnSignup(IdentityResult? identityResult, UserResponse? response)
        {
            if (!identityResult?.Succeeded ?? true)
            {
                Logger.LogError($"error to create user: {identityResult}");
                return CustomBadRequest(errorMessage: "Não foi possível criar sua conta");
            }

            if (response is null)
            {
                Logger.LogError($"error to generate the jwt: NULL");
                return CustomBadRequest(errorMessage: "Não foi possível criar sua conta");
            }

            return StatusCode(StatusCodes.Status201Created, response);
        }

        protected ObjectResult ResultOnSignin(UserResponse? response)
        {
            if (response is null)
            {
                Logger.LogError($"error to generate the jwt: NULL");
                return CustomBadRequest("Não foi possível realizar o login");
            }

            return Ok(response);
        }

        protected ObjectResult ResultWhenUpdating(BaseResponse response)
        {
            return Ok(response);
        }

        protected IActionResult ResultWhenSearching(BaseResponse? response)
        {
            if (response is null) return NotFound();

            return Ok(response);
        }

        protected IActionResult ResultWhenSearching(IEnumerable<BaseResponse>? response)
        {
            if (response is null) return NotFound();
            if (!response.Any()) return NotFound();

            return Ok(response);
        }

        protected IActionResult ResultWhenAdding(IdentityResult result, SignupRequest request)
        {
            if (result.Succeeded)
            {
                Logger.LogInformation("user added");
                return StatusCode(StatusCodes.Status201Created, request.Email); //TODO 201 status code, always has to return an response?
            }

            return CustomBadRequest(result.Errors.Select(x => new ValidationFailure
            {
                ErrorCode = x.Code,
                ErrorMessage = x.Description,
                PropertyName = GenericPropertyName
            }));
        }

        protected IActionResult ResultWhenSignIn(IEnumerable<ValidationFailure> validationFailures)
        {
            Logger.LogInformation("Error to signin");
            return CustomBadRequest(validationFailures);
        }

        protected IActionResult ResultWhenSignIn(Microsoft.AspNetCore.Identity.SignInResult result, UserResponse? userResponse, SigninRequest request)
        {
            if (result.Succeeded)
            {
                Logger.LogInformation($"user signin with username: {request.UserName}");
                return Ok(userResponse);
            }
            if (result.IsLockedOut)
            {
                Logger.LogInformation("user exceeded tentative limit");
                return CustomBadRequest(errorMessage: "User exceeded tentative limit");
            }

            return CustomBadRequest(errorMessage: "Login e/ou senha está incorreto");
        }

        protected ObjectResult InternalServerError(Exception exception, string message)
        {
            Logger.LogError(exception, message);
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

        private BadRequestObjectResult CustomBadRequest(IEnumerable<ValidationFailure> validationFailures)
            => BadRequest(validationFailures);

        protected BadRequestObjectResult CustomBadRequest(string errorMessage)
            => BadRequest(new List<ValidationFailure>
                {
                    new ValidationFailure
                    {
                        PropertyName = GenericPropertyName,
                        ErrorMessage = errorMessage
                    }
            });

        private BadRequestObjectResult CustomBadRequest(string propertyName, string errorMessage)
            => BadRequest(new List<ValidationFailure>
                {
                    new ValidationFailure
                    {
                        PropertyName = propertyName,
                        ErrorMessage = errorMessage
                    }
            });
    }
}

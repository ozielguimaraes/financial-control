using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FinancialControl.Domain.Business.Responses.User;
using FinancialControl.Domain.Business.Requests.User;
using FinancialControl.Domain.Business.Interfaces;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserBusiness _userBusiness;

        public UserController(
            ILogger<UserController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IUserBusiness userBusiness
            ) : base(logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [Route("{userId:int}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"userId: {userId}");
                return ResultWhenSearching(await _userBusiness.GetById(userId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get User by id: {userId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _userBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new User";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - PUT");
                return ResultWhenUpdating(await _userBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update User";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}


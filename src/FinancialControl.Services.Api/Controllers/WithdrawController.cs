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
using FinancialControl.Domain.Business.Responses.Withdraw;
using FinancialControl.Domain.Business.Requests.Withdraw;
using FinancialControl.Domain.Business.Interfaces;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class WithdrawController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWithdrawBusiness _withdrawBusiness;

        public WithdrawController(
            ILogger<WithdrawController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IWithdrawBusiness withdrawBusiness
            ) : base(logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            _withdrawBusiness = withdrawBusiness;
        }

        [HttpGet]
        [Route("{withdrawId:int}")]
        [ProducesResponseType(typeof(WithdrawResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int withdrawId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"withdrawId: {withdrawId}");
                return ResultWhenSearching(await _withdrawBusiness.GetById(withdrawId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get Withdraw by id: {withdrawId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(WithdrawResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateWithdrawRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _withdrawBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new Withdraw";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(WithdrawResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateWithdrawRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - PUT");
                return ResultWhenUpdating(await _withdrawBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update Withdraw";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}


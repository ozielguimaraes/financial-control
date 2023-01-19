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
using FinancialControl.Domain.Business.Responses.Cashier;
using FinancialControl.Domain.Business.Requests.Cashier;
using FinancialControl.Domain.Business.Interfaces;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class CashierController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICashierBusiness _cashierBusiness;

        public CashierController(
            ILogger<CashierController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            ICashierBusiness cashierBusiness
            ) : base(logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            _cashierBusiness = cashierBusiness;
        }

        [HttpGet]
        [Route("{cashierId:int}")]
        [ProducesResponseType(typeof(CashierResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int cashierId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"cashierId: {cashierId}");
                return ResultWhenSearching(await _cashierBusiness.GetById(cashierId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get Cashier by id: {cashierId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CashierResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCashierRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _cashierBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new Cashier";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(CashierResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateCashierRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - PUT");
                return ResultWhenUpdating(await _cashierBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update Cashier";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}


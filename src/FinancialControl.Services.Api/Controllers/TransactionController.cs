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
using FinancialControl.Domain.Business.Responses.Transaction;
using FinancialControl.Domain.Business.Requests.Transaction;
using FinancialControl.Domain.Business.Interfaces;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(
            ILogger<TransactionController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            ITransactionBusiness transactionBusiness
            ) : base(logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            _transactionBusiness = transactionBusiness;
        }

        [HttpGet]
        [Route("{transactionId:int}")]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int transactionId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"transactionId: {transactionId}");
                return ResultWhenSearching(await _transactionBusiness.GetById(transactionId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get Transaction by id: {transactionId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _transactionBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new Transaction";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateTransactionRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - PUT");
                return ResultWhenUpdating(await _transactionBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update Transaction";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}


using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.CashierAccount;
using FinancialControl.Domain.Business.Responses.CashierAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinancialControl.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class CashierAccountController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICashierAccountBusiness _cashierAccountBusiness;

        public CashierAccountController(
            ILogger<CashierAccountController> logger,
            IHttpContextAccessor httpContextAccessor,
            ICashierAccountBusiness cashierAccountBusiness
            ) : base(logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            _cashierAccountBusiness = cashierAccountBusiness;
        }

        [HttpGet]
        [Route("{cashierAccountId:int}")]
        [ProducesResponseType(typeof(CashierAccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int cashierAccountId)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - GET");
                Logger.LogInformation($"cashierAccountId: {cashierAccountId}");
                return ResultWhenSearching(await _cashierAccountBusiness.GetById(cashierAccountId));
            }
            catch (Exception ex)
            {
                var message = $"Error to get CashierAccount by id: {cashierAccountId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CashierAccountResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCashierAccountRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - POST");
                return ResultWhenAdding(await _cashierAccountBusiness.Create(request));
            }
            catch (Exception ex)
            {
                var message = "Error to add new CashierAccount";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(CashierAccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateCashierAccountRequest request)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Get)} - PUT");
                return ResultWhenUpdating(await _cashierAccountBusiness.Update(request));
            }
            catch (Exception ex)
            {
                var message = "Error to update CashierAccount";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [HttpGet]
        [Route("search/{search:alpha}")]
        [ProducesResponseType(typeof(CashierAccountResponse[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Filter([FromBody] string search)
        {
            try
            {
                Logger.LogInformation($"Method: {nameof(Filter)} - GET");
                return ResultWhenSearching(await _cashierAccountBusiness.Filter(search));
            }
            catch (Exception ex)
            {
                var message = $"Error filter CashierAccount, parameter -> {search}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}


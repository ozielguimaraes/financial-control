using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.CashierAccount;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.CashierAccount;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Business.Implementations
{
    public class CashierAccountBusiness : ICashierAccountBusiness
    {
        private readonly ICashierAccountService _cashierAccountService;

        public CashierAccountBusiness(ICashierAccountService cashierAccountService)
        {
            _cashierAccountService = cashierAccountService;
        }

        public async Task<CreateCashierAccountResponse> Create(CreateCashierAccountRequest request)
        {
            //TODO Validate
            var cashierAccount = new CashierAccount();

            var result = await _cashierAccountService.Add(cashierAccount);

            return new CreateCashierAccountResponse(result.CashierAccountId, result.Name);
        }

        public async Task<UpdateCashierAccountResponse> Update(UpdateCashierAccountRequest request)
        {
            //TODO Validate
            var cashierAccount = new CashierAccount();
            var result = await _cashierAccountService.Update(cashierAccount);
            return new UpdateCashierAccountResponse(result.CashierAccountId, result.Name);
        }

        public async Task<List<CashierAccountResponse>> GetAll()
        {
            var result = _cashierAccountService.All();
            return await Task.FromResult(result.Select(x => new CashierAccountResponse(x.CashierAccountId, x.Name)).ToList());
        }

        public async Task<CashierAccountResponse> GetById(long cashierAccountId)
        {
            var result = await _cashierAccountService.GetById(cashierAccountId);
            return new CashierAccountResponse(result.CashierAccountId, result.Name);
        }
    }
}

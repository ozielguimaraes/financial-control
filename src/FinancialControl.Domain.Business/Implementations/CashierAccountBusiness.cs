using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.CashierAccount;
using FinancialControl.Domain.Business.Responses.CashierAccount;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;
using FluentValidation;

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
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            var cashierAccount = new CashierAccount
            {
                Name = request.Name,
                CashierId = request.CashierId
            };

            var result = await _cashierAccountService.Add(cashierAccount);

            return new CreateCashierAccountResponse(result.CashierAccountId, result.Name);
        }

        public async Task<UpdateCashierAccountResponse> Update(UpdateCashierAccountRequest request)
        {
            var cashierAccount = new CashierAccount
            {
                CashierAccountId = request.CashierAccountId,
                CashierId = request.CashierId,
                Name = request.Name
            };

            var result = await _cashierAccountService.Update(cashierAccount);
            return new UpdateCashierAccountResponse(result.CashierAccountId, result.Name);
        }

        public async Task<List<CashierAccountResponse>> GetAll()
        {
            var result = _cashierAccountService.All();
            return await Task.FromResult(result.Select(x => ToDomain(x)).ToList());
        }

        public async Task<CashierAccountResponse> GetById(long cashierAccountId)
        {
            var result = await _cashierAccountService.GetById(cashierAccountId);
            return ToDomain(result);
        }

        public async Task<IEnumerable<CashierAccountResponse>> Filter(string search)
        {
            var result = await _cashierAccountService.Filter(x => x.Name.Contains(search));
            return result.Select(s => ToDomain(s));
        }

        private CashierAccountResponse ToDomain(CashierAccount entity) => new CashierAccountResponse(entity.CashierAccountId, entity.Name, entity.CashierId);
    }
}

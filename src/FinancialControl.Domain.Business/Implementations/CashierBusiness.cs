using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Cashier;
using FinancialControl.Domain.Business.Responses.Cashier;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;
using FluentValidation;

namespace FinancialControl.Domain.Business.Implementations
{
    public class CashierBusiness : ICashierBusiness
    {
        private readonly ICashierService _cashierService;

        public CashierBusiness(ICashierService cashierService)
        {
            _cashierService = cashierService;
        }

        public async Task<CreateCashierResponse> Create(CreateCashierRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            var cashier = new Cashier
            {
                Name = request.Name,
                Description = request.Description
            };

            var result = await _cashierService.Add(cashier);

            return new CreateCashierResponse(result.CashierId, result.Name, result.Description);
        }

        public async Task<UpdateCashierResponse> Update(UpdateCashierRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            if (request.CashierId == 0)
                throw new ValidationException("Campo Id é obrigatório.");

            var cashier = new Cashier
            {
                Name = request.Name,
                CashierId = request.CashierId,
                Description = request.Description
            };
            var result = await _cashierService.Update(cashier);
            return new UpdateCashierResponse(result.CashierId, result.Name);
        }

        public async Task<List<CashierResponse>> GetAll()
        {
            var result = _cashierService.All();
            return await Task.FromResult(result.Select(x => new CashierResponse(x.CashierId, x.Name)).ToList());
        }

        public async Task<CashierResponse> GetById(long cashierId)
        {
            var result = await _cashierService.GetById(cashierId);
            return new CashierResponse(result.CashierId, result.Name);
        }
    }
}

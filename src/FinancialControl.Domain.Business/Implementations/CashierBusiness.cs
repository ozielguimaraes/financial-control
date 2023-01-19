using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Cashier;
using FinancialControl.Domain.Business.Responses.Cashier;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;

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
            if (request.Name is null) throw new ArgumentNullException(nameof(request.Name));

            //TODO Validate
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
            //TODO Validate
            var cashier = new Cashier();
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

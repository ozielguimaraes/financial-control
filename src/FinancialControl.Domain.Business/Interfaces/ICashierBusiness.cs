using FinancialControl.Domain.Business.Requests.Cashier;
using FinancialControl.Domain.Business.Responses.Cashier;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface ICashierBusiness
    {
        Task<CreateCashierResponse> Create(CreateCashierRequest request);
        Task<UpdateCashierResponse> Update(UpdateCashierRequest request);
        Task<CashierResponse> GetById(long cashierId);
    }
}

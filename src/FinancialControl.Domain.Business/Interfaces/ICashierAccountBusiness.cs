using FinancialControl.Domain.Business.Requests.CashierAccount;
using FinancialControl.Domain.Business.Responses.CashierAccount;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface ICashierAccountBusiness
    {
        Task<CreateCashierAccountResponse> Create(CreateCashierAccountRequest request);
        Task<UpdateCashierAccountResponse> Update(UpdateCashierAccountRequest request);
        Task<CashierAccountResponse> GetById(long cashierAccountId);
        Task<IEnumerable<CashierAccountResponse>> Filter(string search);
    }
}

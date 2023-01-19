using FinancialControl.Domain.Business.Requests.Withdraw;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.Withdraw;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface IWithdrawBusiness
    {
        Task<CreateWithdrawResponse> Create(CreateWithdrawRequest request);
        Task<UpdateWithdrawResponse> Update(UpdateWithdrawRequest request);
        Task<WithdrawResponse> GetById(long withdrawId);
    }
}

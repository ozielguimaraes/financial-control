using FinancialControl.Domain.Business.Requests.Transaction;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.Transaction;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface ITransactionBusiness
    {
        Task<CreateTransactionResponse> Create(CreateTransactionRequest request);
        Task<UpdateTransactionResponse> Update(UpdateTransactionRequest request);
        Task<TransactionResponse> GetById(long transactionId);
    }
}

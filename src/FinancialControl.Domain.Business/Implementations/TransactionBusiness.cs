using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Transaction;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.Transaction;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Business.Implementations
{
    public class TransactionBusiness : ITransactionBusiness
    {
        private readonly ITransactionService _transactionService;

        public TransactionBusiness(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<CreateTransactionResponse> Create(CreateTransactionRequest request)
        {
            //TODO Validate
            var transaction = new Transaction();

            var result = await _transactionService.Add(transaction);

            return new CreateTransactionResponse(result.TransactionId, result.Name);
        }

        public async Task<UpdateTransactionResponse> Update(UpdateTransactionRequest request)
        {
            //TODO Validate
            var transaction = new Transaction();
            var result = await _transactionService.Update(transaction);
            return new UpdateTransactionResponse(result.TransactionId, result.Name);
        }

        public async Task<List<TransactionResponse>> GetAll()
        {
            var result = _transactionService.All();
            return await Task.FromResult(result.Select(x => new TransactionResponse(x.TransactionId, x.Name)).ToList());
        }

        public async Task<TransactionResponse> GetById(long transactionId)
        {
            var result = await _transactionService.GetById(transactionId);
            return new TransactionResponse(result.TransactionId, result.Name);
        }
    }
}

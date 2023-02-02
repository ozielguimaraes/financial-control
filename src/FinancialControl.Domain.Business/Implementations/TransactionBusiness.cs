using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Transaction;
using FinancialControl.Domain.Business.Responses.Transaction;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

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
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Campo Nome é obrigatório.");

            if (request.Value > 0)
                throw new ValidationException("Campo Valor é obrigatório.");

            if (request.Value is null)
                throw new ValidationException("Campo Valor é inválido.");

            if (request.CategoryId is null)
                throw new ValidationException("Campo Categoria é obrigatório.");

            if (request.CategoryId > 0)
                throw new ValidationException("Campo Categoria é inválido.");

            if (request.CashierAccountId is null)
                throw new ValidationException("Campo Conta é obrigatório.");

            if (request.CashierAccountId > 0)
                throw new ValidationException("Campo Conta é inválido.");

            if (request.TransactionType is null)
                throw new ValidationException("Campo Tipo Conta é obrigatório.");

            if (request.TransactionType is null)
                throw new ValidationException("Campo Tipo Conta é obrigatório.");

            var transaction = new Transaction
            {
                Name = request.Name,
                Value = request.Value.Value,
                Receipt = request.Receipt,
                TransactionType = (Entities.TransactionType)request.TransactionType.Value,
                CategoryId = request.CategoryId.Value,
                CashierAccountId = request.CashierAccountId.Value
            };

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

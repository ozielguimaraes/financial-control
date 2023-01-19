using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork uow, ITransactionRepository transactionRepository) : base(uow)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            BeginTransaction();
            transaction = _transactionRepository.Add(transaction);
            await CommitAsync();
            return transaction;
        }

        public async Task<Transaction> Update(Transaction transactionUpdated)
        {
            BeginTransaction();
            var transaction = await GetById(transactionUpdated.TransactionId);
            transaction.Update(transactionUpdated);
            transactionUpdated = _transactionRepository.Update(transaction);
            await CommitAsync();
            return transactionUpdated;
        }

        public async Task Remove(long transactionId)
        {
            BeginTransaction();
            _transactionRepository.Remove(await GetById(transactionId));
            await CommitAsync();
        }

        public async Task<Transaction> GetById(long transactionId)
        {
            return await _transactionRepository.GetById(transactionId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<Transaction, bool>> predicate)
        {
            return await _transactionRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<Transaction>> Filter(Expression<Func<Transaction, bool>> predicate)
        {
            return _transactionRepository.Filter(predicate);
        }

        public IQueryable<Transaction> All()
        {
            return _transactionRepository.All();
        }

        public void Dispose()
        {
            _transactionRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

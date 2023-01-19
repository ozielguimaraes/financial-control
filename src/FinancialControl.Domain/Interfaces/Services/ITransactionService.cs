using FinancialControl.Domain.Entities;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface ITransactionService : IDisposable
    {
        Task<Transaction> Add(Transaction obj);
        Task<Transaction> Update(Transaction obj);
        Task Remove(long transactionId);
        Task<Transaction> GetById(long transactionId);
        Task<bool> HasAny(Expression<Func<Transaction, bool>> predicate);
        IQueryable<Transaction> All();
        Task<IQueryable<Transaction>> Filter(Expression<Func<Transaction, bool>> predicate);
    }
}

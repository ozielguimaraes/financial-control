using System.Linq.Expressions;
using FinancialControl.Domain.Entities;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface IWithdrawService : IDisposable
    {
        Task<Withdraw> Add(Withdraw obj);
        Task<Withdraw> Update(Withdraw obj);
        Task Remove(long withdrawId);
        Task<Withdraw> GetById(long withdrawId);
        Task<bool> HasAny(Expression<Func<Withdraw, bool>> predicate);
        IQueryable<Withdraw> All();
        Task<IQueryable<Withdraw>> Filter(Expression<Func<Withdraw, bool>> predicate);
    }
}

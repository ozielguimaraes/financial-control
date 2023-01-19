using System.Linq.Expressions;
using FinancialControl.Domain.Entities;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface ICashierAccountService : IDisposable
    {
        Task<CashierAccount> Add(CashierAccount obj);
        Task<CashierAccount> Update(CashierAccount obj);
        Task Remove(long cashierAccountId);
        Task<CashierAccount> GetById(long cashierAccountId);
        Task<bool> HasAny(Expression<Func<CashierAccount, bool>> predicate);
        IQueryable<CashierAccount> All();
        Task<IQueryable<CashierAccount>> Filter(Expression<Func<CashierAccount, bool>> predicate);
    }
}

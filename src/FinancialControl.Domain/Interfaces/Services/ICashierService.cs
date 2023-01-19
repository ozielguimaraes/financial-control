using FinancialControl.Domain.Entities;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface ICashierService : IDisposable
    {
        Task<Cashier> Add(Cashier obj);
        Task<Cashier> Update(Cashier obj);
        Task Remove(long cashierId);
        Task<Cashier?> GetById(long cashierId);
        Task<bool> HasAny(Expression<Func<Cashier, bool>> predicate);
        IQueryable<Cashier> All();
        Task<IQueryable<Cashier>> Filter(Expression<Func<Cashier, bool>> predicate);
    }
}

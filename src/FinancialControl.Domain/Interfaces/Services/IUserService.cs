using System.Linq.Expressions;
using FinancialControl.Domain.Entities;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        Task<User> Add(User obj);
        Task<User> Update(User obj);
        Task Remove(long userId);
        Task<User> GetById(long userId);
        Task<bool> HasAny(Expression<Func<User, bool>> predicate);
        IQueryable<User> All();
        Task<IQueryable<User>> Filter(Expression<Func<User, bool>> predicate);
    }
}

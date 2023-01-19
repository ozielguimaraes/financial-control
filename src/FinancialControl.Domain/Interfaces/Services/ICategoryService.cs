using FinancialControl.Domain.Entities;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Interfaces.Services
{
    public interface ICategoryService : IDisposable
    {
        Task<Category> Add(Category obj);
        Task<Category> Update(Category obj);
        Task Remove(long categoryId);
        Task<Category> GetById(long category);
        Task<bool> HasAny(Expression<Func<Category, bool>> predicate);
        IQueryable<Category> All();
        Task<IQueryable<Category>> Filter(Expression<Func<Category, bool>> predicate);
    }
}

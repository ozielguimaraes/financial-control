using System;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Remove(TEntity obj);
        Task<TEntity?> GetById(long id);
        Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> All(); 
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}

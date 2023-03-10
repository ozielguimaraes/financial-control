using System.Linq.Expressions;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MainContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);
            return obj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public async virtual Task<TEntity?> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async virtual Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public virtual IQueryable<TEntity> All()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public async virtual Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

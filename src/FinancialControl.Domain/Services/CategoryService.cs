using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork uow, ICategoryRepository categoryRepository) : base(uow)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Add(Category category)
        {
            BeginTransaction();
            category = _categoryRepository.Add(category);
            await CommitAsync();
            return category;
        }

        public async Task<Category> Update(Category categoryUpdated)
        {
            BeginTransaction();
            var category = await GetById(categoryUpdated.CategoryId);
            category.Update(categoryUpdated);
            categoryUpdated = _categoryRepository.Update(category);
            await CommitAsync();
            return categoryUpdated;
        }

        public async Task Remove(long cashierId)
        {
            BeginTransaction();
            var item = await GetById(cashierId);
            if (item is not null)
            {
                _categoryRepository.Remove(item);
                await CommitAsync();
            }
        }

        public async Task<Category?> GetById(long cashierId)
        {
            return await _categoryRepository.GetById(cashierId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<Category, bool>> predicate)
        {
            return await _categoryRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<Category>> Filter(Expression<Func<Category, bool>> predicate)
        {
            return _categoryRepository.Filter(predicate);
        }

        public IQueryable<Category> All()
        {
            return _categoryRepository.All();
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

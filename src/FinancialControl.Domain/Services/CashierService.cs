using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Services
{
    public class CashierService : BaseService, ICashierService
    {
        private readonly ICashierRepository _categoryRepository;

        public CashierService(IUnitOfWork uow, ICashierRepository cashierRepository) : base(uow)
        {
            _categoryRepository = cashierRepository;
        }

        public async Task<Cashier> Add(Cashier cashier)
        {
            BeginTransaction();
            cashier = _categoryRepository.Add(cashier);
            await CommitAsync();
            return cashier;
        }

        public async Task<Cashier> Update(Cashier cashierUpdated)
        {
            BeginTransaction();
            var cashier = await GetById(cashierUpdated.CashierId);
            cashier.Update(cashierUpdated);
            cashierUpdated = _categoryRepository.Update(cashier);
            await CommitAsync();
            return cashierUpdated;
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

        public async Task<Cashier?> GetById(long cashierId)
        {
            return await _categoryRepository.GetById(cashierId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<Cashier, bool>> predicate)
        {
            return await _categoryRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<Cashier>> Filter(Expression<Func<Cashier, bool>> predicate)
        {
            return await Task.FromResult(_categoryRepository.Filter(predicate));
        }

        public IQueryable<Cashier> All()
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

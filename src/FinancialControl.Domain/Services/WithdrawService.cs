using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace FinancialControl.Domain.Services
{
    public class WithdrawService : BaseService, IWithdrawService
    {
        private readonly IWithdrawRepository _withdrawRepository;

        public WithdrawService(IUnitOfWork uow, IWithdrawRepository withdrawRepository) : base(uow)
        {
            _withdrawRepository = withdrawRepository;
        }

        public async Task<Withdraw> Add(Withdraw withdraw)
        {
            BeginTransaction();
            withdraw = _withdrawRepository.Add(withdraw);
            await CommitAsync();
            return withdraw;
        }

        public async Task<Withdraw> Update(Withdraw withdrawUpdated)
        {
            BeginTransaction();
            var withdraw = await GetById(withdrawUpdated.WithdrawId);
            withdraw.Update(withdrawUpdated);
            withdrawUpdated = _withdrawRepository.Update(withdraw);
            await CommitAsync();
            return withdrawUpdated;
        }

        public async Task Remove(long withdrawId)
        {
            BeginTransaction();
            _withdrawRepository.Remove(await GetById(withdrawId));
            await CommitAsync();
        }

        public async Task<Withdraw> GetById(long withdrawId)
        {
            return await _withdrawRepository.GetById(withdrawId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<Withdraw, bool>> predicate)
        {
            return await _withdrawRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<Withdraw>> Filter(Expression<Func<Withdraw, bool>> predicate)
        {
            return _withdrawRepository.Filter(predicate);
        }

        public IQueryable<Withdraw> All()
        {
            return _withdrawRepository.All();
        }

        public void Dispose()
        {
            _withdrawRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

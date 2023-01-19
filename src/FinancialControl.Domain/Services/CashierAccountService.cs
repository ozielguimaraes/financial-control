using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Services
{
    public class CashierAccountService : BaseService, ICashierAccountService
    {
        private readonly ICashierAccountRepository _cashieraccountRepository;

        public CashierAccountService(IUnitOfWork uow, ICashierAccountRepository cashieraccountRepository) : base(uow)
        {
            _cashieraccountRepository = cashieraccountRepository;
        }

        public async Task<CashierAccount> Add(CashierAccount cashierAccount)
        {
            BeginTransaction();
            cashierAccount = _cashieraccountRepository.Add(cashierAccount);
            await CommitAsync();
            return cashierAccount;
        }

        public async Task<CashierAccount> Update(CashierAccount cashierAccountUpdated)
        {
            BeginTransaction();
            var cashierAccount = await GetById(cashierAccountUpdated.CashierAccountId);
            cashierAccount.Update(cashierAccountUpdated);
            cashierAccountUpdated = _cashieraccountRepository.Update(cashierAccount);
            await CommitAsync();
            return cashierAccountUpdated;
        }

        public async Task Remove(long cashierAccountId)
        {
            BeginTransaction();
            _cashieraccountRepository.Remove(await GetById(cashierAccountId));
            await CommitAsync();
        }

        public async Task<CashierAccount> GetById(long cashierAccountId)
        {
            return await _cashieraccountRepository.GetById(cashierAccountId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<CashierAccount, bool>> predicate)
        {
            return await _cashieraccountRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<CashierAccount>> Filter(Expression<Func<CashierAccount, bool>> predicate)
        {
            return _cashieraccountRepository.Filter(predicate);
        }

        public IQueryable<CashierAccount> All()
        {
            return _cashieraccountRepository.All();
        }

        public void Dispose()
        {
            _cashieraccountRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

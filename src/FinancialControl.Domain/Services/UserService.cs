using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository userRepository) : base(uow)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Add(User user)
        {
            BeginTransaction();
            user = _userRepository.Add(user);
            await CommitAsync();
            return user;
        }

        public async Task<User> Update(User userUpdated)
        {
            BeginTransaction();
            var user = await GetById(userUpdated.UserId);
            user.Update(userUpdated);
            userUpdated = _userRepository.Update(user);
            await CommitAsync();
            return userUpdated;
        }

        public async Task Remove(long userId)
        {
            BeginTransaction();
            _userRepository.Remove(await GetById(userId));
            await CommitAsync();
        }

        public async Task<User> GetById(long userId)
        {
            return await _userRepository.GetById(userId);
        }

        public async virtual Task<bool> HasAny(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.HasAnyAsync(predicate);
        }

        public async Task<IQueryable<User>> Filter(Expression<Func<User, bool>> predicate)
        {
            return await Task.FromResult(_userRepository.Filter(predicate));
        }

        public IQueryable<User> All()
        {
            return _userRepository.All();
        }

        public void Dispose()
        {
            _userRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

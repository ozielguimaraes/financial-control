using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.User;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.User;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Business.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserService _userService;

        public UserBusiness(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserResponse> Create(CreateUserRequest request)
        {
            //TODO Validate
            var user = new User();

            var result = await _userService.Add(user);

            return new CreateUserResponse(result.UserId, result.Name);
        }

        public async Task<UpdateUserResponse> Update(UpdateUserRequest request)
        {
            //TODO Validate
            var user = new User();
            var result = await _userService.Update(user);
            return new UpdateUserResponse(result.UserId, result.Name);
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var result = _userService.All();
            return await Task.FromResult(result.Select(x => new UserResponse(x.UserId, x.Name)).ToList());
        }

        public async Task<UserResponse> GetById(long userId)
        {
            var result = await _userService.GetById(userId);
            return new UserResponse(result.UserId, result.Name);
        }
    }
}

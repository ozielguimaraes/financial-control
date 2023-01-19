using FinancialControl.Domain.Business.Requests.User;
using FinancialControl.Domain.Business.Responses;
using FinancialControl.Domain.Business.Responses.User;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<CreateUserResponse> Create(CreateUserRequest request);
        Task<UpdateUserResponse> Update(UpdateUserRequest request);
        Task<UserResponse> GetById(long userId);
    }
}

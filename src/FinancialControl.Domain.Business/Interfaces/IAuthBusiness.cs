using FinancialControl.Domain.Business.Requests.Auth;
using FinancialControl.Domain.Business.Responses.Auth;

namespace FinancialControl.Domain.Business.Interfaces
{
    public interface IAuthBusiness
    {
        Task<SignupResponse> Validate(SignupRequest request);
        Task<SigninResponse> Validate(SigninRequest request);
    }
}

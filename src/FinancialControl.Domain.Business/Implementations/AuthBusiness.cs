using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Business.Requests.Auth;
using FinancialControl.Domain.Business.Responses.Auth;
using FinancialControl.Domain.Interfaces.Services;

namespace FinancialControl.Domain.Business.Implementations
{
    public class AuthBusiness : IAuthBusiness
    {
        public async Task<SignupResponse> Validate(SignupRequest request)
        {
            //TODO Validate, use FluentValidations
            
            if (string.IsNullOrWhiteSpace(request.UserName))
                throw new NullReferenceException("UserName is required");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new NullReferenceException("Email is required");
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new NullReferenceException("Name is required");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new NullReferenceException("Password is required");
            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                throw new NullReferenceException("ConfirmPassword is required");
            if (request.ConfirmPassword != request.Password)
                throw new NullReferenceException("ConfirmPassword is different to Password");

            return new SignupResponse();
        }

        public async Task<SigninResponse> Validate(SigninRequest request)
        {
            //TODO Validate, use FluentValidations
            if (string.IsNullOrWhiteSpace(request.UserName))
                throw new NullReferenceException("UserName is required");
            if (string.IsNullOrWhiteSpace(request.Password))
                throw new NullReferenceException("Password is required");
        
            return new SigninResponse();
        }
    }
}

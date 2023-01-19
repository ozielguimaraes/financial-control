using System;

namespace FinancialControl.Domain.Business.Responses.User
{
    public class CreateUserResponse : BaseResponse
    {
        public CreateUserResponse(long userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    public bool Active { get; private set; }
    }
}

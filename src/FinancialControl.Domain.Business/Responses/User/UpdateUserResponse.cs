using System;

namespace FinancialControl.Domain.Business.Responses.User
{
    public class UpdateUserResponse : BaseResponse
    {
        public UpdateUserResponse(long userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    public string RecoverCode { get; private set; }
    public bool Active { get; private set; }
    }
}

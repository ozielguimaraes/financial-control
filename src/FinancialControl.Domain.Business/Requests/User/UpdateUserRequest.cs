using System;

namespace FinancialControl.Domain.Business.Requests.User
{
    public class UpdateUserRequest
    {
        public long userId { get; set; }
        public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string RecoverCode { get; set; }
            public bool Active { get; set; }
    }
}


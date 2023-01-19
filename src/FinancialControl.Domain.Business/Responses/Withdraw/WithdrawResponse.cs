using System;

namespace FinancialControl.Domain.Business.Responses.Withdraw
{
    public class WithdrawResponse : BaseResponse
    {
        public WithdrawResponse(long withdrawId, string name)
        {
            WithdrawId = withdrawId;
            Name = name;
        }

        public long WithdrawId { get; private set; }
        public string Name { get; private set; }
        
    }
}

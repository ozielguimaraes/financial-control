using System;

namespace FinancialControl.Domain.Business.Responses.Withdraw
{
    public class CreateWithdrawResponse : BaseResponse
    {
        public CreateWithdrawResponse(long withdrawId, string name)
        {
            WithdrawId = withdrawId;
            Name = name;
        }

        public long WithdrawId { get; private set; }
        public string Name { get; private set; }
        
    }
}

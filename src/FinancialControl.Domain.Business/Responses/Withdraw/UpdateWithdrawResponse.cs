using System;

namespace FinancialControl.Domain.Business.Responses.Withdraw
{
    public class UpdateWithdrawResponse : BaseResponse
    {
        public UpdateWithdrawResponse(long withdrawId, string name)
        {
            WithdrawId = withdrawId;
            Name = name;
        }

        public long WithdrawId { get; private set; }
        public string Name { get; private set; }
        
    }
}

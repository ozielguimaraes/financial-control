using System;

namespace FinancialControl.Domain.Business.Requests.Withdraw
{
    public class UpdateWithdrawRequest
    {
        public long withdrawId { get; set; }
        public string Name { get; set; }
    }
}


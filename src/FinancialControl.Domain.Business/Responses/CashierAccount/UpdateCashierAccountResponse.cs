using System;

namespace FinancialControl.Domain.Business.Responses.CashierAccount
{
    public class UpdateCashierAccountResponse : BaseResponse
    {
        public UpdateCashierAccountResponse(long cashierAccountId, string name)
        {
            CashierAccountId = cashierAccountId;
            Name = name;
        }

        public long CashierAccountId { get; private set; }
        public string Name { get; private set; }
        
    }
}

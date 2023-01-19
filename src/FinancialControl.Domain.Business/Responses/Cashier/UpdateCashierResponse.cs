using System;

namespace FinancialControl.Domain.Business.Responses.Cashier
{
    public class UpdateCashierResponse : BaseResponse
    {
        public UpdateCashierResponse(long cashierId, string name)
        {
            CashierId = cashierId;
            Name = name;
        }

        public long CashierId { get; private set; }
        public string Name { get; private set; }
        
    }
}

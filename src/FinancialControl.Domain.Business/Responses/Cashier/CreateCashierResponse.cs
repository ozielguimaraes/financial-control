using System;

namespace FinancialControl.Domain.Business.Responses.Cashier
{
    public class CreateCashierResponse : BaseResponse
    {
        public CreateCashierResponse(long cashierId, string name, string description)
        {
            CashierId = cashierId;
            Name = name;
            Description = description;
        }

        public long CashierId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}

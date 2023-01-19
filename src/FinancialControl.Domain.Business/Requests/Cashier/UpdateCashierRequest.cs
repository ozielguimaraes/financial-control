using System;

namespace FinancialControl.Domain.Business.Requests.Cashier
{
    public class UpdateCashierRequest
    {
        public long cashierId { get; set; }
        public string Name { get; set; }
    }
}


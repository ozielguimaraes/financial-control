using System;

namespace FinancialControl.Domain.Business.Requests.CashierAccount
{
    public class UpdateCashierAccountRequest
    {
        public long cashierAccountId { get; set; }
        public string Name { get; set; }
    }
}


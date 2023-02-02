namespace FinancialControl.Domain.Business.Requests.CashierAccount
{
    public class UpdateCashierAccountRequest
    {
        public long CashierAccountId { get; set; }
        public string Name { get; set; }
        public long CashierId { get; set; }
    }
}

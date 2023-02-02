namespace FinancialControl.Domain.Business.Requests.CashierAccount
{
    public class CreateCashierAccountRequest
    {
        public string Name { get; set; }
        public long CashierId { get; set; }
    }
}

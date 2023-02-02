namespace FinancialControl.Domain.Business.Requests.Cashier
{
    public class UpdateCashierRequest
    {
        public long CashierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

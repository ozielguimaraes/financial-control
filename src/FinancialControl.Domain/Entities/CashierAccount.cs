namespace FinancialControl.Domain.Entities
{
    public class CashierAccount
    {
        public long CashierAccountId { get; set; }
        public string Name { get; set; }

        public long CashierId { get; set; }
        public Cashier Cashier { get; set; }

        public void Update(CashierAccount cashierAccountUpdated)
        {
            //TODO Update properties
        }
    }
}

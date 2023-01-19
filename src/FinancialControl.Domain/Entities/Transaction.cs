namespace FinancialControl.Domain.Entities
{
    public class Transaction
    {
        public long TransactionId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Receipt { get; set; }

        public long CategoryId { get; set; }
        public Category? Category { get; set; }

        public long CashierAccountId { get; set; }
        public CashierAccount? CashierAccount { get; set; }

        public void Update(Transaction transactionUpdated)
        {
            //TODO Update properties
        }
    }
}

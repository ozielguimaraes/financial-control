namespace FinancialControl.Domain.Business.Requests.Transaction
{
    public class CreateTransactionRequest
    {
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public string Receipt { get; set; }
        public TransactionType? TransactionType { get; set; }
        public long? CategoryId { get; set; }
        public long? CashierAccountId { get; set; }
    }
}

namespace FinancialControl.Domain.Business.Requests.Transaction
{
    public class CreateTransactionRequest
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Receipt { get; set; }
    }
}


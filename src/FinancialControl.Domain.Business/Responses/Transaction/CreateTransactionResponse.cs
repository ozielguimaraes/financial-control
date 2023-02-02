namespace FinancialControl.Domain.Business.Responses.Transaction
{
    public class CreateTransactionResponse : BaseResponse
    {
        public CreateTransactionResponse(long transactionId, string name)
        {
            TransactionId = transactionId;
            Name = name;
        }

        public long TransactionId { get; private set; }
        public string Name { get; private set; }
    }
}

using FinancialControl.Domain.Business.Requests.Transaction;

namespace FinancialControl.Domain.Business.Responses.Transaction
{
    public class TransactionResponse : BaseResponse
    {
        public TransactionResponse(long transactionId, decimal value, string name, TransactionType transactionType, long categoryId, long cashierAccountId)
        {
            TransactionId = transactionId;
            Value = value;
            Name = name;
            TransactionType = transactionType;
            CategoryId = categoryId;
            CashierAccountId = cashierAccountId;
        }

        public long TransactionId { get; private set; }
        public decimal Value { get; private set; }
        public string Name { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public long CategoryId { get; private set; }
        public long CashierAccountId { get; private set; }
    }
}

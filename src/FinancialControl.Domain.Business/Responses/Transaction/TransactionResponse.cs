using System;

namespace FinancialControl.Domain.Business.Responses.Transaction
{
    public class TransactionResponse : BaseResponse
    {
        public TransactionResponse(long transactionId, string name)
        {
            TransactionId = transactionId;
            Name = name;
        }

        public long TransactionId { get; private set; }
        public string Name { get; private set; }
        
    }
}

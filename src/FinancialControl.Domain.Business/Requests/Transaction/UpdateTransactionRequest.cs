using System;

namespace FinancialControl.Domain.Business.Requests.Transaction
{
    public class UpdateTransactionRequest
    {
        public long transactionId { get; set; }
        public string Name { get; set; }
    }
}


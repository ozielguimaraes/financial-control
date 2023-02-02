namespace FinancialControl.Domain.Business.Responses.CashierAccount
{
    public class CashierAccountResponse : BaseResponse
    {
        public CashierAccountResponse(long cashierAccountId, string name, long cashierId)
        {
            CashierAccountId = cashierAccountId;
            Name = name;
            CashierId = cashierId;
        }

        public long CashierAccountId { get; private set; }
        public string Name { get; private set; }
        public long CashierId { get; private set; }
    }
}

namespace FinancialControl.Domain.Business.Responses.Cashier
{
    public class CashierResponse : BaseResponse
    {
        public CashierResponse(long cashierId, string name)
        {
            CashierId = cashierId;
            Name = name;
        }

        public long CashierId { get; private set; }
        public string Name { get; private set; }
    }
}

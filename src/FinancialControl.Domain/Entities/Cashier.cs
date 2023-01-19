namespace FinancialControl.Domain.Entities
{
    public class Cashier
    {
        public long CashierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Update(Cashier cashierUpdated)
        {
            //TODO Update properties
        }
    }
}

using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;

namespace FinancialControl.Infra.Data.Repositories
{
    public class CashierRepository : Repository<Cashier>, ICashierRepository
    {
        public CashierRepository(MainContext context) : base(context) { }
    }
}
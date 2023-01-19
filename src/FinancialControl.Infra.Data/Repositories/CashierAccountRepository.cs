using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;

namespace FinancialControl.Infra.Data.Repositories
{
    public class CashierAccountRepository : Repository<CashierAccount>, ICashierAccountRepository
    {
        public CashierAccountRepository(MainContext context) : base(context) { }
    }
}

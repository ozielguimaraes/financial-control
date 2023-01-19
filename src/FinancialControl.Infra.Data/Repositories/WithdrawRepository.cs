using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;

namespace FinancialControl.Infra.Data.Repositories
{
    public class WithdrawRepository : Repository<Withdraw>, IWithdrawRepository
    {
        public WithdrawRepository(MainContext context) : base(context) { }
    }
}

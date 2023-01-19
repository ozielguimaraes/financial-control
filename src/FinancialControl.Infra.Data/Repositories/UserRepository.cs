using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;

namespace FinancialControl.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainContext context) : base(context) { }
    }
}

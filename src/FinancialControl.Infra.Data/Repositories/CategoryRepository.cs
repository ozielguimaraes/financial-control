using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.Data.Context;

namespace FinancialControl.Infra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MainContext context) : base(context) { }
    }
}
using System.Threading.Tasks;
using FinancialControl.Domain.Interfaces;

namespace FinancialControl.Domain.Services
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _uow.CommitAsync();
        }
    }
}

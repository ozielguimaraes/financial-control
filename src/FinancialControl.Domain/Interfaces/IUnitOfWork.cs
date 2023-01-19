using System.Threading.Tasks;

namespace FinancialControl.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        Task<int> CommitAsync();
    }
}

using Microsoft.EntityFrameworkCore.Storage;

namespace CQRS_poc.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void Dispose();
        IDbContextTransaction BeginTransaction();
    }
}

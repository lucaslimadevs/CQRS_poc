using CQRS_poc.Domain.Repositories;
using CQRS_poc.Infra.Sqlite.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CQRS_poc.Infra.Sqlite.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

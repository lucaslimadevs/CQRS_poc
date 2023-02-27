using CQRS_poc.Domain.Repositories;
using CQRS_poc.Infra.Sqlite.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS_poc.Infra.Sqlite.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        public readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);            
        }

        public async Task AddRangeAsync(TEntity entity)
        {
            await DbSet.AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {            
            DbSet.Update(entity);
        }
    }
}

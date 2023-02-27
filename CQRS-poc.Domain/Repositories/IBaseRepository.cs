namespace CQRS_poc.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(TEntity entity);
        void Update(TEntity entity);
    }
}

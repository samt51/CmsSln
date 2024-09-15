namespace Cms.Shared.Abstract.Repositories
{
    public interface IWriteRepository<T> where T : class, new()
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        void UpdateRange(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}

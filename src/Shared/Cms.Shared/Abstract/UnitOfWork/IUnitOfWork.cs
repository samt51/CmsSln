using Cms.Shared.Abstract.Repositories;

namespace Cms.Shared.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
        void OpenTransaction();
        Task<int> SaveAsync();
        void Commit();
        void RollBack();
    }
}

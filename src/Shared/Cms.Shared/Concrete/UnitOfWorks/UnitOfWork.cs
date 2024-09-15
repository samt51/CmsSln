using Cms.Shared.Abstract.Repositories;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cms.Shared.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Commit()
        {
            dbContext.Database.CommitTransaction();
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public void OpenTransaction()
        {
            dbContext.Database.BeginTransactionAsync();
        }

        public void RollBack()
        {
            dbContext.Database.RollbackTransaction();
        }


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);



        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(dbContext);
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                var result = await dbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
}

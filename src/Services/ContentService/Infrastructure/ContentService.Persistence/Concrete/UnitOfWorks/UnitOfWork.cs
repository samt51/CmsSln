using Cms.Shared.Abstract.Repository;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Concrete.Repository;
using ContentService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentService.Persistence.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContentDbContext _dbContext;

        public UnitOfWork(ContentDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CommitAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

        public void OpenTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);



        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
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

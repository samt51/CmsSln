﻿using Cms.Shared.Abstract.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cms.Shared.Concrete.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {

            var tab = await Table.AddAsync(entity).ConfigureAwait(false);
            return tab.Entity;

        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

      
        public void UpdateRange(IList<T> entities)
        {
            Table.UpdateRange(entities);
        }
    }
}

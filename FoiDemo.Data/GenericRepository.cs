using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoiDemo.Data.Interfaces;
using FoiDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoiDemo.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private DatabaseContext dbContext { get; }

        public GenericRepository(DatabaseContext context)
        {
            dbContext = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllAsReadOnly()
        {
            return dbContext.Set<TEntity>()
                .AsNoTracking();
        }

        public IQueryable<TEntity> GetById(Guid id)
        {
            return dbContext.Set<TEntity>().Where(e => e.Id == id);
        }

        public void Delete(TEntity item)
        {
            dbContext.Set<TEntity>().Remove(item);
        }

        public void Insert(TEntity item)
        {
            dbContext.Set<TEntity>().Add(item);
        }

        public void InsertMultiple(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public async Task<bool> SaveAsync()
        {
            return await dbContext.SaveChangesAsync() >= 0;
        }
    }
}
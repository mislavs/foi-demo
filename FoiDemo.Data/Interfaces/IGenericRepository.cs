using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoiDemo.Data.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetById(Guid id);
        
        void Insert(TEntity entity);

        void InsertMultiple(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetAllAsReadOnly();
        
        Task<bool> SaveAsync();
    }
}

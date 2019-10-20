using FoiDemo.Data.Interfaces;
using FoiDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoiDemo.Business.Services.Base
{
    public abstract class EntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IGenericRepository<TEntity> _repository;

        public EntityService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async virtual Task<TEntity> GetById(Guid id)
        {
            return await _repository.GetById(id).SingleOrDefaultAsync();
        }

        public async virtual Task<bool> Save(TEntity entity)
        {
            _repository.Insert(entity);
            return await _repository.SaveAsync();
        }

        public async virtual Task<bool> Delete(TEntity entity)
        {
            _repository.Delete(entity);
            return await _repository.SaveAsync();
        }

        public async virtual Task<bool> DeleteById(Guid id)
        {
            var entity = await GetById(id);
            return await Delete(entity);
        }
    }
}

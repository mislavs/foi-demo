using AutoMapper;
using FoiDemo.Business.Services.Base;
using FoiDemo.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoiDemo.API.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class EntityController<TEntity, TDto, TForCreateDto, TService> : ControllerBase
        where TEntity : BaseEntity
        where TDto : class
        where TForCreateDto : class
        where TService : EntityService<TEntity>
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        public EntityController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async virtual Task<ActionResult<List<TDto>>> Get()
        {
            var entities = await _service.GetAll();
            return _mapper.Map<List<TDto>>(entities);
        }

        [HttpGet("{id:guid}")]
        public async virtual Task<ActionResult<TDto>> GetById(Guid id)
        {
            var entity = await _service.GetById(id);
            return _mapper.Map<TDto>(entity);
        }

        [HttpPost]
        public async virtual Task<ActionResult<TDto>> Save(TForCreateDto entityForCreate)
        {
            var entity = _mapper.Map<TEntity>(entityForCreate);
            
            if (!(await _service.Save(entity)))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                var entityDto = _mapper.Map<TDto>(entity);
                return Ok(entityDto);
            }
        }

        [HttpDelete("{id:guid}")]
        public async virtual Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _service.DeleteById(id);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Enums;
using week3_huseyingulerman.Core.Result.Abstract;
using week3_huseyingulerman.Core.Result.Concrete;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Core.UnitOfWork;
using week3_huseyingulerman.Service.Exceptions;

namespace week3_huseyingulerman.Service.Servcices
{
    public class Service<TEntity, TRequest, TResponse> : IService<TEntity, TRequest, TResponse> where TEntity : BaseEntity where TRequest : class where TResponse : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public Service(IUnitOfWork uow, IMapper mapper)
        {
            _uow =uow;
            _mapper=mapper;
        }
        public async Task<IAppResult<TResponse>> AddAsync(TRequest request)
        {
            var newEntity = _mapper.Map<TEntity>(request);
            await _uow.GetRepository<TEntity>().AddAsync(newEntity);
            await _uow.CommitAsync();

            var newResponse = _mapper.Map<TResponse>(newEntity);
            return AppResult<TResponse>.Success(StatusCodes.Status200OK, newResponse);
        }

        public async Task<IAppResult<IEnumerable<TResponse>>> AddRangeAsync(IEnumerable<TRequest> requests)
        {
            var newEntities = _mapper.Map<IEnumerable<TEntity>>(requests);
            await _uow.GetRepository<TEntity>().AddRangeAsync(newEntities);
            await _uow.CommitAsync();

            var newResponses = _mapper.Map<IEnumerable<TResponse>>(newEntities);
            return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, newResponses);
        }

        public async Task<IAppResult<IEnumerable<TResponse>>> GetAllActiveAsync(Arrangement sort)
        {
            if (Arrangement.IdHighToLow== sort)
            {
                var entities = await _uow.GetRepository<TEntity>().GetAllActive().OrderByDescending(x => x.Id).ToListAsync(); var responseEntities = _mapper.Map<IEnumerable<TResponse>>(entities);
                return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responseEntities);
            }
            else if (Arrangement.TemperatureLowToHigh== sort)
            {return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK);
                /*  var entities = await _uow.GetRepository<TEntity>().GetAllActive().OrderBy(x => x.Temperature).ToListAsync(); *//*var responseEntities = _mapper.Map<IEnumerable<TResponse>>(entities);*/
                //return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responseEntities);
            }
            else if (Arrangement.TemperatureHighToLow== sort)
            {
                ///* var entities = await _uow.GetRepository<TEntity>().GetAllActive().OrderByDescending(x => x.Temperature).ToListAsync(); */var responseEntities = _mapper.Map<IEnumerable<TResponse>>(entities);
                // return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responseEntities);
                return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK);
            }
            else
            {
                var entities = await _uow.GetRepository<TEntity>().GetAllActive().ToListAsync(); var responseEntities = _mapper.Map<IEnumerable<TResponse>>(entities);
                return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responseEntities);
            }
        }

        public async Task<IAppResult<IEnumerable<TResponse>>> GetAllAsync()
        {
            var entities = await _uow.GetRepository<TEntity>().GetAll().ToListAsync();
            var responseEntities = _mapper.Map<IEnumerable<TResponse>>(entities);

            return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responseEntities);
        }

        public async Task<IAppResult<TResponse>> GetByIdAsync(int id)
        {
            var entity = await _uow.GetRepository<TEntity>().GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"{typeof(TEntity).Name}({id}) does not exist");

            var response = _mapper.Map<TResponse>(entity);

            return AppResult<TResponse>.Success(StatusCodes.Status200OK, response);
        }

        public async Task<IAppResult<NoContentDTO>> RemoveAsync(int id)
        {
            var entity = await _uow.GetRepository<TEntity>().GetByIdAsync(id);
            _uow.GetRepository<TEntity>().Remove(entity);
            await _uow.CommitAsync();
            return AppResult<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<IAppResult<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> ids)
        {

            var entities = await _uow.GetRepository<TEntity>().Where(x => ids.Contains(x.Id)).ToListAsync();
            _uow.GetRepository<TEntity>().RemoveRange(entities);
            await _uow.CommitAsync();
            return AppResult<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<IAppResult<NoContentDTO>> UpdateAsync(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _uow.GetRepository<TEntity>().Update(entity);
            await _uow.CommitAsync();

            return AppResult<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<IAppResult<IEnumerable<TResponse>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _uow.GetRepository<TEntity>().Where(expression).ToListAsync();
            var responses = _mapper.Map<IEnumerable<TResponse>>(entities);

            return AppResult<IEnumerable<TResponse>>.Success(StatusCodes.Status200OK, responses); throw new NotImplementedException();
        }
    }
}

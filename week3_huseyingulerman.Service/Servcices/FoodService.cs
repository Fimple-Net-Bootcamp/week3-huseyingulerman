using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.UnitOfWork;
using AutoMapper;
using week3_huseyingulerman.Core.Result.Abstract;
using week3_huseyingulerman.Core.Repositories;
using week3_huseyingulerman.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using week3_huseyingulerman.Core.Result.Concrete;

namespace week3_huseyingulerman.Service.Servcices
{
    public class FoodService : Service<Food, FoodCreateDTO, FoodDTO>, IFoodService
    {
        protected readonly IUnitOfWork _uow;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        public FoodService(IFoodRepository foodRepository,IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
            _foodRepository=foodRepository;
            _mapper=mapper;
            _uow=uow;
        }

        public async Task<IAppResult<FoodDTO>> AddFoodByPetId(FoodCreateDTO foodCreateDTO)
        {
            var newEntity = _mapper.Map<Food>(foodCreateDTO);
            await _foodRepository.AddFoodByPetId(newEntity);
            await _uow.CommitAsync();
            var newResponse = _mapper.Map<FoodDTO>(newEntity);

            return AppResult<FoodDTO>.Success(StatusCodes.Status200OK, newResponse);
        }

        public async Task<List<Food>> GetFoodByPetId(int id)
        {
            var foods = await _foodRepository.GetFoodByPetId(id);

            return foods;
        }
    }
}

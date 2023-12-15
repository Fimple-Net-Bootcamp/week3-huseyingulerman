using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Result.Abstract;

namespace week3_huseyingulerman.Core.Services
{
    public interface IFoodService : IService<Food, FoodCreateDTO, FoodDTO>
    {
        Task<IAppResult<FoodDTO>> AddFoodByPetId(FoodCreateDTO foodCreateDTO);
   
    }
}

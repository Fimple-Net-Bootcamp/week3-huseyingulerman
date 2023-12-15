using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Entities;

namespace week3_huseyingulerman.Core.Services
{
    public interface IHealthService:IService<Health,HealthCreateDTO,HealthDTO>
    {
        Task<HealthDTO> GetHealtyByPetId(int id);
    }
}

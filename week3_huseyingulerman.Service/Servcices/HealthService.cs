using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Repositories;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Core.UnitOfWork;

namespace week3_huseyingulerman.Service.Servcices
{
    public class HealthService : Service<Health, HealthCreateDTO, HealthDTO>, IHealthService
    {
        private readonly IHealthRepository _healthRepository;
        private readonly IMapper _mapper;
        public HealthService( IUnitOfWork uow, IHealthRepository healthRepository, IMapper mapper) : base(uow, mapper)
        {
            _healthRepository=healthRepository;
            _mapper=mapper;
        }

        public async Task<HealthDTO> GetHealtyByPetId(int id)
        {
           var health= await _healthRepository.GetHealtyByPetId(id);
            var healthDTO=_mapper.Map<HealthDTO>(health);
            return healthDTO;
        }
    }
}

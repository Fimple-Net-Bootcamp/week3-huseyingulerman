using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Entities;
using week3_huseyingulerman.Core.Services;
using week3_huseyingulerman.Core.UnitOfWork;

namespace week3_huseyingulerman.Service.Servcices
{
    public class PetService : Service<Pet, PetCreateDTO, PetDTO>, IPetService
    {
        public PetService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}

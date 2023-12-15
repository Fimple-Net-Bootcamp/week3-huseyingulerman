using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.Entities;

namespace week3_huseyingulerman.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, UserDTO>();
            CreateMap<UserCreateDTO, AppUser>();
            CreateMap<UserDTO, UserCreateDTO>();
            CreateMap<UserCreateDTO, UserDTO>();

        }
    }
}

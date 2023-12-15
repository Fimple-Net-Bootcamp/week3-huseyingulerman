using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.DTOs;
using week3_huseyingulerman.Core.DTOs.Create;
using week3_huseyingulerman.Core.DTOs.Update;
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


            CreateMap<Pet, PetDTO>();
            CreateMap<PetCreateDTO, Pet>();
            CreateMap<PetDTO, PetCreateDTO>();
            CreateMap<PetCreateDTO, PetDTO>();
            CreateMap<PetUpdateDTO, Pet>();

            CreateMap<Health, HealthDTO>();
            CreateMap<HealthCreateDTO, Health>();
            CreateMap<HealthDTO, HealthCreateDTO>();
            CreateMap<HealthCreateDTO, HealthDTO>();

            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityCreateDTO, Activity>();
            CreateMap<ActivityDTO, ActivityCreateDTO>();
            CreateMap<ActivityCreateDTO, ActivityDTO>();

            CreateMap<Food, FoodDTO>();
            CreateMap<FoodCreateDTO, Food>();
            CreateMap<FoodDTO, FoodCreateDTO>();
            CreateMap<FoodCreateDTO, FoodDTO>();


        }
    }
}

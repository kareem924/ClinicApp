using Abstract.Entities;
using Application.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }
}

using AutoMapper;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Repository.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ServiceEntity, ServiceResponseDTO>();
            CreateMap<UserEntity, UserResponseDTO>();
        }


    }
}

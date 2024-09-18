using AutoMapper;
using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Context;
using GlobalMind.DAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Repository.Interface
{
    public interface IServiceRepository
    {
        Task<string> AddService(ServiceCreateRequestDTO serviceCreate);
        Task<List<ServiceResponseDTO>> GetService();
    }
}

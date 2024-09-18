using AutoMapper;
using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Context;
using GlobalMind.DAO.Entities;
using GlobalMind.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly GlobalMindDbContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(GlobalMindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddService(ServiceCreateRequestDTO serviceCreate)
        {
            if (serviceCreate == null)
            {
                throw new ArgumentException("Sai dữ liệu Service");
            }

            if (await _context.Service.AnyAsync(x => x.Name.ToLower().Equals(serviceCreate.Name.ToLower()) && x.IsDeleted == false))
                throw new Exception("Tên Service đã tồn tại");
            

            var service = new ServiceEntity()
            {
                Name = serviceCreate.Name,
                ImageUrl = serviceCreate.ImageUrl,
                Description = serviceCreate.Description,
                Price = serviceCreate.Price,
                Status = true,
                IsDeleted = false,
            };  

            _context.Service.Add(service);
            if (await _context.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Create Failed";
        }

        public async Task<List<ServiceResponseDTO>> GetService()
        {
            var services = await _context.Service.Where(x => x.IsDeleted == false).ToListAsync();

            if (!services.Any())
                throw new Exception("Không tìm thấy Service");

            return _mapper.Map<List<ServiceResponseDTO>>(services);
        }
    }
}

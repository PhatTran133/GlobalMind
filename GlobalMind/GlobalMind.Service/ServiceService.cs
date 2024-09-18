using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.Repository.Interface;
using GlobalMind.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<string> AddService(ServiceCreateRequestDTO serviceCreate)
        {
            return await _serviceRepository.AddService(serviceCreate);
        }

        public async Task<List<ServiceResponseDTO>> GetService()
        {
            return await _serviceRepository.GetService();
        }
    }
}

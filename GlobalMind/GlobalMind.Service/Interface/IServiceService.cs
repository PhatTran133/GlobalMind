using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Service.Interface
{
    public interface IServiceService
    {
        Task<string> AddService(ServiceCreateRequestDTO serviceCreate);
        Task<List<ServiceResponseDTO>> GetService();
    }
}

using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.ResponseType;
using GlobalMind.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMind.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost("add-service")]
        public async Task<ActionResult<JsonResponse<string>>> AddService([FromBody] ServiceCreateRequestDTO serviceCreateRequest)
        {
            try
            {
                var result = await _serviceService.AddService(serviceCreateRequest);
                return Ok(new JsonResponse<string>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpGet("get-service")]
        public async Task<ActionResult<JsonResponse<List<ServiceResponseDTO>>>> GetService()
        {
            try
            {
                var result = await _serviceService.GetService();
                return Ok(new JsonResponse<List<ServiceResponseDTO>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }
    }
}

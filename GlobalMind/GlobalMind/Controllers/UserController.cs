using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.ResponseType;
using GlobalMind.Service;
using GlobalMind.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMind.Controllers
{
    [ApiController]
    [Route("api/v1")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequestDTO requestDTO)
        {
            try
            {
                var email = requestDTO.Email;
                if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest(new JsonResponse<string>("Email phải thuộc miền @gmail.com"));
                }
                var isCreated = await _userService.CreateUser(requestDTO);
                if (!isCreated)
                {
                    return BadRequest("Không thể tạo tài khoản.");
                }
                return Ok(new JsonResponse<string>("Đăng ký thành công. Vui lòng kiểm tra email để xác nhận OTP."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<JsonResponse<UserResponseDTO>>> Login(LoginRequestDTO requestDTO)
        {
            try
            {
                var email = requestDTO.Email;
                if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest(new JsonResponse<string>("Email phải thuộc miền @gmail.com"));
                }

                var result = await _userService.LoginAsync(requestDTO);
                return Ok(new JsonResponse<UserResponseDTO>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpGet("get-users")]
        public async Task<ActionResult<JsonResponse<List<UserResponseDTO>>>> GetUsers(string? fullName, bool? gender, bool? status)
        {
            try
            {
                var result = await _userService.GetUsersAsync(fullName, gender, status);
                return Ok(new JsonResponse<List<UserResponseDTO>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<JsonResponse<UserResponseDTO>>> GetUserById(int id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);
                return Ok(new JsonResponse<UserResponseDTO>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpPut("update-user")]
        public async Task<ActionResult<JsonResponse<string>>> UpdateUser(UserUpdateRequestDTO requestDTO)
        {
            try
            {
                var result = await _userService.UpdateUserAsync(requestDTO);
                return Ok(new JsonResponse<string>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpPut("update-user-status")]
        public async Task<ActionResult<JsonResponse<string>>> UpdateUserStatus(int id, bool status)
        {
            try
            {
                var result = await _userService.UpdateUserStatusAsync(id, status);
                return Ok(new JsonResponse<string>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }

        [HttpDelete("delete-user")]
        public async Task<ActionResult<JsonResponse<string>>> DeleteUser(int id)
        {
            try
            {   
                var result = await _userService.DeleteUserAsync(id);
                return Ok(new JsonResponse<string>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse<string>(ex.Message));
            }
        }
    }
}

using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.Repository.Interface;
using GlobalMind.ResponseType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalMind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IUserRepository _userRepository;

        public OtpController(IOtpRepository otpRepository, IUserRepository userRepository)
        {
            _otpRepository = otpRepository;
            _userRepository = userRepository;
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDTO requestDTO)
        {
            // Kiểm tra mã OTP
            var otpEntity = await _otpRepository.GetOtpByEmailAsync(requestDTO.Email);
            if (otpEntity == null || otpEntity.Code != requestDTO.Code || otpEntity.ExpiryTime < DateTime.UtcNow)
            {
                return BadRequest(new JsonResponse<string>("Mã OTP không hợp lệ hoặc đã hết hạn."));
            }

            // Lấy tài khoản người dùng
            var user = await _userRepository.GetUserByEmailAsync(requestDTO.Email);
            if (user == null)
            {
                return NotFound(new JsonResponse<string>("Không tìm thấy tài khoản người dùng."));
            }

            // Xác nhận tài khoản của người dùng
            await _userRepository.VerifyUserAccountAsync(user);

            // Xoá mã OTP sau khi xác nhận thành công
            await _otpRepository.DeleteOtpAsync(otpEntity);

            return Ok(new JsonResponse<int>(user.Id));
        }
    }
}

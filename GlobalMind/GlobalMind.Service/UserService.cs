using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Entities;
using GlobalMind.Repository.Interface;
using GlobalMind.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpRepository _otpRepository; 
        private readonly IEmailService _emailService;    

        public UserService(IUserRepository userRepository, IOtpRepository otpRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _otpRepository = otpRepository;
            _emailService = emailService;
        }

        public async Task<bool> CreateUser(RegisterAccountRequestDTO requestDTO)
        {
            
            var isCreated = await _userRepository.CreateUser(requestDTO);
            if (!isCreated) throw new Exception("Không thể tạo tài khoản");

            // Tạo mã OTP và lưu vào database
            var otpCode = new Random().Next(100000, 999999).ToString();
            var otpExpiryTime = DateTime.UtcNow.AddMinutes(5); // Mã OTP hết hạn sau 5 phút
            await _otpRepository.SaveOtpAsync(new OtpEntity
            {
                Email = requestDTO.Email,
                Code = otpCode,
                ExpiryTime = otpExpiryTime
            });

            // Gửi mã OTP qua email
            var subject = "Xác nhận tài khoản của bạn";
            var body = $"Mã xác nhận của bạn là {otpCode}. Mã này sẽ hết hạn sau 5 phút.";
            await _emailService.SendEmailAsync(requestDTO.Email, subject, body);

            return true;
        }
        public async Task VerifyUserAccountAsync(UserEntity userEntity)
        {
            await _userRepository.VerifyUserAccountAsync(userEntity);
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
           
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<UserResponseDTO>> GetUsersAsync(string? fullName, bool? gender, bool? status)
        {
            return await _userRepository.GetUsersAsync(fullName, gender, status);
        }

        public async Task<UserResponseDTO> LoginAsync(LoginRequestDTO requestDTO)
        {
            return await _userRepository.LoginAsync(requestDTO);
        }

        public async Task<string> UpdateUserAsync(UserUpdateRequestDTO requestDTO)
        {
            return await _userRepository.UpdateUserAsync(requestDTO);
        }

        public async Task<string> UpdateUserStatusAsync(int id, bool status)
        {
            return await _userRepository.UpdateUserStatusAsync(id, status);
        }

        

        
    }
}

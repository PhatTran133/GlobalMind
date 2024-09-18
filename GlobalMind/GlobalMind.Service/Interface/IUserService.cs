using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Service.Interface
{
    public interface IUserService
    {
        Task<bool> CreateUser(RegisterAccountRequestDTO requestDTO);
        Task<UserEntity> GetUserByEmailAsync(string email);
        Task VerifyUserAccountAsync(UserEntity userEntity);
        Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task<string> UpdateUserAsync(UserUpdateRequestDTO requestDTO);
        Task<string> DeleteUserAsync(int id);
        Task<string> UpdateUserStatusAsync(int id, bool status);
        Task<List<UserResponseDTO>> GetUsersAsync(string? fullName, bool? gender, bool? status);
        Task<UserResponseDTO> LoginAsync(LoginRequestDTO requestDTO);
    }
}


using AutoMapper;
using GlobalMind.BOs.DTOs.RequestDTOs;
using GlobalMind.BOs.DTOs.ResponseDTOs;
using GlobalMind.DAO.Context;
using GlobalMind.DAO.Entities;
using GlobalMind.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GlobalMindDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(GlobalMindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(RegisterAccountRequestDTO requestDTO)
        {
            var user = await _context.User.AnyAsync(x => x.Email.Equals(requestDTO.Email) && x.IsDeleted == false && x.IsVerified == true);
            if (user) throw new Exception("Email is used");

            var newUser = new UserEntity()
            {
                Email = requestDTO.Email,
                Password = requestDTO.Password,
                IsVerified = false,
                Role = "customer",
                Status = false
            };

            _context.User.Add(newUser);
            if (await _context.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }

        //Lấy tài khoản chưa Verified
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false && x.IsVerified == false && x.Status == false);
        }

        public async Task VerifyUserAccountAsync(UserEntity userEntity)
        {
            userEntity.IsVerified = true;
            userEntity.Status = true;
            _context.User.Update(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("User is not found");

            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<string> UpdateUserAsync(UserUpdateRequestDTO requestDTO)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == requestDTO.Id && x.IsDeleted == false && x.IsVerified == true);
            if (user == null) throw new Exception("User is not found");

            var phone = await _context.User.AnyAsync( x => x.Phone.Equals(requestDTO.Phone) && x.IsDeleted == false && x.IsVerified == true);
            if (phone) throw new Exception("Phone numeber is used");

            user.FullName = requestDTO.FullName;
            user.Gender = requestDTO.Gender;
            user.DateOfBirth = requestDTO.DateOfBirth;
            user.Phone = requestDTO.Phone;
            user.Address = requestDTO.Address;

            _context.User.Update(user);
            if (await _context.SaveChangesAsync() > 0)
                return "Update Successfully";
            else
                return "Update Failed";

        }

        public async Task<string> DeleteUserAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.IsVerified == true);
            if (user == null) throw new Exception("User is not found");

            user.IsDeleted = true;

            _context.User.Update(user);
            if (await _context.SaveChangesAsync() > 0)
                return "Update Successfully";
            else
                return "Update Failed";
        }

        public async Task<string> UpdateUserStatusAsync (int id, bool status)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false && x.IsVerified == true);
            if (user == null) throw new Exception("User is not found");

            user.Status = status;
            _context.User.Update(user);
            if (await _context.SaveChangesAsync() > 0)
                return "Update Successfully";
            else
                return "Update Failed";
        }

        public async Task<List<UserResponseDTO>> GetUsersAsync(string? fullName, bool? gender, bool? status)
        {
            var query = _context.User.AsQueryable();

            if (!string.IsNullOrEmpty(fullName))
            {
                query = query.Where(x => x.FullName.Contains(fullName) && x.IsDeleted == false && x.IsVerified == true);
            }

            if (gender.HasValue)
            {
                query = query.Where(x => x.Gender == gender.Value && x.IsDeleted == false && x.IsVerified == true);
            }

            if (status.HasValue)
            {
                query = query.Where(x => x.Status == status.Value && x.IsDeleted == false && x.IsVerified == true);
            }

            var users = await query.ToListAsync();

            return _mapper.Map<List<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO> LoginAsync(LoginRequestDTO requestDTO)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Email.Equals(requestDTO.Email));
            if (user == null || !user.Password.Equals(requestDTO.Password)) throw new Exception("Wrong Email or Password");
            if (user.Status == false) throw new Exception("Your account is banned");
            return _mapper.Map<UserResponseDTO>(user);
        }
    }
}

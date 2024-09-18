using GlobalMind.BOs.DTOs.RequestDTOs;
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
    public class OtpRepository : IOtpRepository
    {
        private readonly GlobalMindDbContext _context;

        public OtpRepository(GlobalMindDbContext context)
        {
            _context = context;
        }

        public async Task SaveOtpAsync(OtpEntity otpEntity)
        {
            _context.Otp.Add(otpEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<OtpEntity> GetOtpByEmailAsync(string email)
        {
            return await _context.Otp.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task DeleteOtpAsync(OtpEntity otpEntity)
        {
            _context.Otp.Remove(otpEntity);
            await _context.SaveChangesAsync();
        }
    }
}

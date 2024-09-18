using GlobalMind.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.Repository.Interface
{
    public interface IOtpRepository
    {
        Task SaveOtpAsync(OtpEntity otpEntity);
        Task<OtpEntity> GetOtpByEmailAsync(string email);
        Task DeleteOtpAsync(OtpEntity otpEntity);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.BOs.DTOs.RequestDTOs
{
    public class VerifyOtpRequestDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Code is required.")]
        public string Code { get; set; }
    }
}

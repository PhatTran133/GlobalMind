using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public bool IsVerified { get; set; }
        public bool Status { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }

    }
}

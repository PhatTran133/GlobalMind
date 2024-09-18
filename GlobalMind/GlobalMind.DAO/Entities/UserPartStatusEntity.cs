using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("UserPartStatus")]
    public class UserPartStatusEntity : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public int PartId { get; set; }
        [ForeignKey(nameof(PartId))]
        public PartEntity Part { get; set; }
        public bool Status { get; set; }
    }
}

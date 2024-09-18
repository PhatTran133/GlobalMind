using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public string Payment {  get; set; }
        public DateTime Date { get; set; }
        public decimal Total {  get; set; }

        public ICollection<CourseDetailEntity> CourseDetails { get; set; }
        public ICollection<ServiceDetailEntity> ServiceDetails { get; set; }
    }
}

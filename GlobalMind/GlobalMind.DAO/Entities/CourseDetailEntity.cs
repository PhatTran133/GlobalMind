using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("CourseDetail")]
    public class CourseDetailEntity : BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public OrderEntity Order { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public CourseEntity Course { get; set; }
        public string Action {  get; set; }
    }
}

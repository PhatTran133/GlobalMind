using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("Lesson")]
    public class LessonEntity : BaseEntity
    {
        public int PartId { get; set; }
        [ForeignKey(nameof(PartId))]
        public PartEntity Part { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; } 
    }
}

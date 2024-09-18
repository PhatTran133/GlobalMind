using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("Part")]
    public class PartEntity : BaseEntity
    {
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public CourseEntity Course { get; set; }
        public string Name { get; set; }
        public ICollection<LessonEntity> Lessons { get; set; }
    }
}

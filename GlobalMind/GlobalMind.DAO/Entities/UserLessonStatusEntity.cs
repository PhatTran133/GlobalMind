using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("UserLessonStatus")]
    public class UserLessonStatusEntity : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public int LessonId { get; set; }
        [ForeignKey(nameof(LessonId))]
        public LessonEntity Lesson { get; set; }
        public bool Status { get; set; }
    }
}

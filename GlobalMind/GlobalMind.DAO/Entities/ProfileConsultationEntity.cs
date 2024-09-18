using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("ProfileConsultation")]
    public class ProfileConsultationEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string Country {  get; set; }
        public string Major {  get; set; }
        public string AcademicAward { get; set; }
        public string GPA { get; set; }
        public string Certificate { get; set; }
    }
}

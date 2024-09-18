using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMind.DAO.Entities
{
    [Table("ServiceDetail")]
    public class ServiceDetailEntity : BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public OrderEntity Order { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public ServiceEntity Service { get; set; }
        public string Action { get; set; }
    }
}

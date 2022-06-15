using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model
{
    public class StatusOrder
    {
        [Required]
        public int StatusOrderId { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}

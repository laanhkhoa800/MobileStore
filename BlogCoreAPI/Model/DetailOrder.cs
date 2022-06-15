using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model
{
    public class DetailOrder
    {
        public int DetailOrderId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int SubProductId { get; set; }
        public double Price { get; set; }
        public  Order Order { get; set; }
        public  SubProduct SubProduct { get; set; }

    }
}

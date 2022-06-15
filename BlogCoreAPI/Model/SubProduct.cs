using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlogCoreAPI.Model
{
    public class SubProduct
    {
        public int SubProductId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int StatusId { get; set; } 
        public bool IsDelete { get; set; } = false;
        public  Status Status { get; set; } 
        public  Product Product { get; set; }
        public ICollection<DetailOrder> DetailOrders { get; set; }
    }
}

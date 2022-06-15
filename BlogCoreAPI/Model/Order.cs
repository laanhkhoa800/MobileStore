using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCoreAPI.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int StatusOrderId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }
       /* [ForeignKey("StatusId")]*/
        public StatusOrder StatusOrder { get; set; }
       /* [ForeignKey("UserId")]*/
        public  User User { get; set; }
        public ICollection<DetailOrder> DetailOrders { get; set; }
    }
}

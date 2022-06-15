using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model.ViewModel
{
    public class OrderView
    {
        public int UserId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlogCoreAPI.Model
{
    public class Product
    {
        public int ProductId { get; set; }      
        public string Name { get; set; }
        /*[Required]*/
        public int StyleId { get; set; }        
        public int Quantity { get; set; } = 0;
        public string ImageMain { get; set; }
        public string ImageSecon { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        [Required]
        public double Price { get; set; }
        public double? PriceSales { get; set; }
        public ulong View { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Description { get; set; }
        public virtual Style Style { get; set; }
        public virtual IEnumerable<SubProduct> SubProducts { get; set; }
    }
}

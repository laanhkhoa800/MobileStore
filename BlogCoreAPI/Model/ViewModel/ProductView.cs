using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Model.ViewModel
{
    public class ProductView
    {
        public string Name { get; set; }
        public int StyleId { get; set; }
        public string ImageMain { get; set; }
        public string ImageSecon { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public double Price { get; set; }
        public double? PriceSales { get; set; }

        public string Description { get; set; }
    }
}

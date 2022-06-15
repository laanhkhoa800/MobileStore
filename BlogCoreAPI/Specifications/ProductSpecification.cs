using Ardalis.Specification;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification()
        {
            Query.Where(item => item.IsDelete.Equals(false));
        }
    }
    public class SearchProductSpecification : Specification<Product>
    {
        public   SearchProductSpecification(string search)
        {
           var a = Query.Where(item => item.IsDelete.Equals(false) && item.Name.Contains(search) || item.Style.Name.Contains(search)||item.Price.Equals(search));
           
        }
        public void Search(string s)
        {
            var a = Query.Where(item => item.IsDelete.Equals(false) && item.Name.Contains(s) || item.Style.Name.Contains(s) || item.Price.Equals(s));
        }
    }
}

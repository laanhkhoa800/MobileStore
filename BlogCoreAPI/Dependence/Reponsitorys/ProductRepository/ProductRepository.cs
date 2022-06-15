using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.ProductRepository
{
    public class ProductRepository :  BaseRepository<Product>,IProductRepository
    {
        private ApContext _apContext;
        public ProductRepository(ApContext context) : base(context)
        {
            _apContext = context;
        }
        public IEnumerable<Product> GetBySearch(string search)
        {
            return _apContext.products.Where(s => s.IsDelete.Equals(false) && s.Name.Contains(search) || s.Price.ToString().Contains(search) || s.Style.Name.Contains(search)).ToList();
        }

        public IEnumerable<Product> GetProductByStyle(string style)
        {
            return _apContext.products.Where(s => s.IsDelete.Equals(false) &&  s.Style.Name.Contains(style)).ToList();
        }
    }
}

using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetBySearch(string search);
        IEnumerable<Product> GetProductByStyle(string style);

    }
}

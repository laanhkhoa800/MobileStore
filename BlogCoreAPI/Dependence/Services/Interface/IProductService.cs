using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public interface IProductService 
    {
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> GetAllProductBySearch(string search);
        IEnumerable<Product> GetAllProductByStyle(string style);

        IEnumerable<Product> GetProductOfUserID(int ID);
        Product GetProductById(int id);
        void AddNewProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void ChangeIsDelete(Product product);
        void Save();
    
    }
}

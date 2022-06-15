using BlogCoreAPI.Dependence.Reponsitorys;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services.Interface
{
    public interface ISubProductService 
    {
        void AddNewProduct(SubProduct subProduct);
        SubProduct GetSubByProId(int ProductId);
        void UpdateSubProduct(SubProduct subProduct);
        IEnumerable<SubProduct> CountSubOfProductId(int productId);
        IEnumerable<SubProduct> getSubProductByProductId(int productId);

        void Save();
    }
}

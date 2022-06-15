using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys
{
    public interface ISubProductRepository : IBaseRepository<SubProduct>
    {
        SubProduct GetSubByProId(int ProductId);
        IEnumerable<SubProduct> CountSubProNoActiveByProductId(int ProductId);
        IEnumerable<SubProduct> getSubbyproductId(int ProductId);
    }
}

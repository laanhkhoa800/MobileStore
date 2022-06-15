using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.SubProductRepository
{
    public class SubProductRepository : BaseRepository<SubProduct>, ISubProductRepository
    {
        private ApContext _apContext;
        public SubProductRepository(ApContext context) : base(context)
        {
            _apContext = context;
        }

        public IEnumerable<SubProduct> CountSubProNoActiveByProductId(int ProductId)
        {
            return _apContext.subProducts.Where(s => s.ProductId == ProductId && s.StatusId == 1 && s.IsDelete == false).ToList();
        }

        public IEnumerable<SubProduct> getSubbyproductId(int ProductId)
        {
            return _apContext.subProducts.Where(s => s.ProductId == ProductId && s.ProductId == 1 && s.IsDelete == false).ToList();
           
        }

        public SubProduct GetSubByProId(int ProductId)
        {
            return _apContext.subProducts.Where(s => s.ProductId == ProductId && s.StatusId == 1 && s.IsDelete == false).FirstOrDefault();
        }
    }
}

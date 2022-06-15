using BlogCoreAPI.Dependence.Reponsitorys;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public class SubProductService : ISubProductService 
    {
        private readonly IBaseRepository<SubProduct> _baseRepository;
        private ISubProductRepository _subProductRepository;
        public SubProductService(IBaseRepository<SubProduct> baseRepository, ISubProductRepository subProductRepository)
        {
            this._baseRepository = baseRepository;
            this._subProductRepository = subProductRepository;
        }
        public void AddNewProduct(SubProduct subProduct)
        {
            subProduct.IsDelete = false;
             _baseRepository.Inser(subProduct);
             _baseRepository.Save();
        }

        public IEnumerable<SubProduct> CountSubOfProductId(int productId)
        {
            return _subProductRepository.CountSubProNoActiveByProductId(productId);
        }

        public SubProduct GetSubByProId(int ProductId)
        {
            return _subProductRepository.GetSubByProId(ProductId);
        }

        public IEnumerable<SubProduct> getSubProductByProductId(int productId)
        {
            return _subProductRepository.getSubbyproductId(productId); 
        }

        public void Save()
        {
            _subProductRepository.Save();
        }

        public void UpdateSubProduct(SubProduct subProduct)
        {
            _subProductRepository.Update(subProduct);
        }
    }
}

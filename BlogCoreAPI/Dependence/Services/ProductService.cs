using Ardalis.Specification;
using BlogCoreAPI.Dependence.Reponsitorys.ProductRepository;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public class ProductService : IProductService
    {
        //Khởi tạo giá tri
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            //gán giá trị cho khởi tạo 
            this._productRepository = productRepository;
        }

        public void AddNewProduct(Product product)
        {
            if(product != null)
            {
                product.IsDelete = false;
                product.View = 0;
                product.Quantity = 0;
                product.CreateAt = DateTime.Now;
                _productRepository.Inser(product);
                _productRepository.Save();
            }    
        }

        public void ChangeIsDelete(Product product)
        {
            product.IsDelete = true;
            _productRepository.Update(product);
            _productRepository.Save();

        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        
        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllProductBySearch(string search)
        {
            return _productRepository.GetBySearch(search);
        }

        public IEnumerable<Product> GetAllProductByStyle(string style)
        {
            return _productRepository.GetProductByStyle(style);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetByID(id);
        }

        public IEnumerable<Product> GetProductOfUserID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            product.UpdateAt = DateTime.Now;
            _productRepository.Update(product);
            _productRepository.Save();

        }

    }
    public class ProductIncompleteIsDeleteSpecificationv : Specification<Product>
    {
        public ProductIncompleteIsDeleteSpecificationv()
        {
            Query.Where(item => item.IsDelete == false);
        }
    }
    public class ProductByIDIncompleteIsDeleteSpecificationv : Specification<Product>
    {
        public ProductByIDIncompleteIsDeleteSpecificationv(int id)
        {
            Query.Where(item => item.IsDelete == false && item.ProductId.Equals(id));
        }
    }
}

using BlogCoreAPI.Dependence.Services;
using BlogCoreAPI.Model;
using BlogCoreAPI.Model.PaginationParams;
using BlogCoreAPI.Model.ViewModel;
using BlogCoreAPI.Specifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlogCoreAPI.Controllers
{
    [EnableCors("mypolicy")]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger; 
        private IProductService _ProductService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _ProductService = productService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("GetAllProduct")]
        public IEnumerable<Product> GetAllProduct([FromBody]ModelSearch search)
        {
            if (search.textsearch != null)
            {
                //var complete = new SearchProductSpecification(search);
                var products = _ProductService.GetAllProductBySearch(search.textsearch);            
                foreach (var product in products)
                {
                    if (product.IsDelete == false)
                    {
                        yield return product;
                    }
                }
            }
            else
            {
                var products = _ProductService.GetAllProduct();              
                foreach (var product in products)
                {
                    if (product.IsDelete == false)
                    {
                        yield return product;
                    }
                }
            }
            /* if (search.textsearch != null)
             {
                 //var complete = new SearchProductSpecification(search);
                 var products = _ProductService.GetAllProductBySearch(search.textsearch)
                 .Skip((@params.Page - 1) * @params.ItemsPerPage)
                 .Take(@params.ItemsPerPage);
                 var paginationMetadata = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);
                 Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                 var items = products.Skip((@params.Page - 1) * @params.ItemsPerPage).Take(@params.ItemsPerPage).ToList();
                 foreach (var product in items)
                 {
                     if (product.IsDelete == false)
                     {
                         yield return product;
                     }
                 }
             }
             else
             {
                 var products = _ProductService.GetAllProduct()
                 .Skip((@params.Page - 1) * @params.ItemsPerPage)
                 .Take(@params.ItemsPerPage);
                 var paginationMetadata = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);
                 Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                 var items = products.Skip((@params.Page - 1) * @params.ItemsPerPage).Take(@params.ItemsPerPage).ToList();
                 foreach (var product in items)
                 {
                     if (product.IsDelete == false)
                     {
                         yield return product;
                     }
                 }
             }*/
        }
        [HttpPost("GetProductByStyle")]
        public IEnumerable<Product> GetProductByStyle([FromBody] ModelSearch style)
        {
                //var complete = new SearchProductSpecification(search);
                var products = _ProductService.GetAllProductByStyle(style.textsearch);
                foreach (var product in products)
                {
                        yield return product;
                }     
        }
        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _ProductService.GetProductById(id);
            product.View += 1;
            _ProductService.UpdateProduct(product);
            return Ok(product);
        }
        [HttpGet("AdminGetById/{id}")]
        public IActionResult AdminGetById(int id)
        {
            var product = _ProductService.GetProductById(id);
            return Ok(product);
        }
        //[Authorize]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProductView request)
        {
            var item = new Product();
            item.Name = request.Name;
            item.StyleId = request.StyleId;
            item.Price = request.Price;             
            item.ImageMain = request.ImageMain;
            item.ImageSecon = request.ImageSecon;
            item.Image3 = request.Image3;
            item.Image4 = request.Image4;
            item.Image5 = request.Image5;
            item.Description = request.Description;
            _ProductService.AddNewProduct(item);
            return Ok();
        }
        /*[HttpPost("Add")]
        public IActionResult Add([FromForm] ProductView request, CancellationToken cancellationToken = default)
        {
            var item = new Product();
            item.Name = request.Name;
            item.StyleId = request.StyleId;
            item.PriceSales = request.PriceSales;
            item.Price = request.Price;
            item.IsDelete = request.IsDelete;
            item.CreateAt = DateTime.Now;
            item.Image = request.Image.ToString();
            var files = HttpContext.Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file.Name);
                    var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                    var path = Path.Combine("", hostingEnvironment.ContentRootPath + "/Images/" + newfilename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _ProductService.AddNewProduct(item);
                }

            }
            return Ok();
        }*/
        /* [HttpPost("AddProduct")]
         public IActionResult AddNewProduct([FromForm]Product product)
         {
             var files = HttpContext.Request.Form.Files;
             if (files != null && files.Count > 0)
             {
                 foreach (var file in files)
                 {
                     FileInfo fi = new FileInfo(file.Name);
                     var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                     var path = Path.Combine("", hostingEnvironment.ContentRootPath + "/Images/" + newfilename);
                     using (var stream = new FileStream(path, FileMode.Create))
                     {
                         file.CopyTo(stream);
                     }
                     _ProductService.AddNewProduct(product);
                 }
             }

             return Ok();
         }*/

        [HttpPut("EditProduct/{id}")]
        public IActionResult EditProdyct(int id,[FromBody] ProductView request)
        {
            var existingItem = _ProductService.GetProductById(id);
            if (existingItem == null) return BadRequest();
            else
            {
                existingItem.ProductId = id;
                existingItem.Name = request.Name;
                existingItem.Price = request.Price;
                existingItem.ImageMain = request.ImageMain;
                existingItem.ImageSecon = request.ImageSecon;
                existingItem.Image3 = request.Image3;
                existingItem.Image4 = request.Image4;
                existingItem.Image5 = request.Image5;
                existingItem.StyleId = request.StyleId;
                existingItem.PriceSales = request.PriceSales;
                existingItem.Description = request.Description;

                _ProductService.UpdateProduct(existingItem);

            }
            return Ok();
        }
        [HttpPut("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingItem = _ProductService.GetProductById(id);
            if (existingItem == null) return BadRequest();
            else
            {
                existingItem.IsDelete = true;
            }
            _ProductService.ChangeIsDelete(existingItem);
            return Ok();
        }
        
    
        //public IEnumerable<Product> GetProdcutById(int id)
        //{
        //    var check = new ProductByIDIncompleteIsDeleteSpecificationv(id);
        //    return _ProductService.GetAllProduct();
        //}
        /*  [HttpGet("/GetAllProduct")]
          public  async Task<ActionResult<Product>> HandleAsync(CancellationToken cancellationToken)
          {
              var createdItem =  _ProductService.GetAllProduct();
              return Ok(createdItem);
          }

          [HttpGet("/GetProductById")]
          public async Task<ActionResult<Product>> GetProDuctById(CancellationToken cancellationToken)
          {

          }
  */
    }
}

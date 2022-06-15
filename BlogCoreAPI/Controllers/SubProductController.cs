
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using BlogCoreAPI.Model.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class SubProductController : ControllerBase
    {
        private ISubProductService _SubProductService;
        private readonly ILogger<SubProductController> _logger;
        public SubProductController(ILogger<SubProductController> logger, ISubProductService subProductService)
        {
            _SubProductService = subProductService;
            _logger = logger;
        }
        [HttpPost("AddSubProduct")]
        public IActionResult AddSubProduct([FromForm]SubProductView subProduct)
        {
            var p = new SubProduct();
            p.ProductId = subProduct.ProductId;
            p.StatusId = subProduct.StatusId;
            _SubProductService.AddNewProduct(p);
            return Ok();
        }
        [HttpGet]
        public IEnumerable<SubProduct> getSubProductByProductId(int productId)
        {
           var items = _SubProductService.getSubProductByProductId(productId);
            foreach (var item in items)
            {
                    yield return item;
            }
        }
    }
}

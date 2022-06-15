using BlogCoreAPI.Dependence.Services;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using BlogCoreAPI.Model.MailKit;
using BlogCoreAPI.Model.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreAPI.Controllers
{

    [EnableCors("mypolicy")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private ISendMailService _sendMailService;
        private IUserService _userService;
        private IDetailOrderService _detailOrderService;
        private IOrderService _orderService;
        private ISubProductService _subproductService;
        private IProductService _productService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger,IProductService productService,ISubProductService subProductService,IOrderService orderService,IDetailOrderService detailOrderService,IConfiguration configuration, ISendMailService sendMailService, IUserService userService)
        {
            _detailOrderService = detailOrderService;
            _userService = userService;
            _sendMailService = sendMailService;
            _logger = logger;
            _configuration = configuration;
            _orderService = orderService;
            _subproductService = subProductService;
            _productService = productService;
        }

        [HttpPost("GetAllUser")]
        public IEnumerable<User> GetAllUser([FromBody] ModelSearch search)
        {
            if(search.textsearch != null)
            {
                var items = _userService.GetAllUserBySearch(search.textsearch);
                foreach (var user in items)
                {
                    if (user.IsDelete == false)
                    {
                        yield return user;
                    }
                }
            }
            else
            {
                var users = _userService.GetAllUser();
                foreach (var user in users)
                {
                    if (user.IsDelete == false)
                    {
                        yield return user;
                    }
                }
            }
            
        }
        [HttpGet("GetAllUserByStatus")]
        public IEnumerable<User> GetAllUsetByStatus(int status)
        {
            var users = _userService.GetUserByStatus(status);
            foreach (var user in users)
            {
                if (user.IsDelete == false)
                {
                    yield return user;
                }
            }
        }
        [HttpPost("LoginToken")]
        public IActionResult LoginToken([FromBody] UserLogin userData)
        {
            if(userData != null && userData.Email != null && userData.Passwork != null)
            {
                var user =  _userService.GetUser(userData.Email, userData.Passwork);
                if(user != null)
                {
                    //Create claims details based on the user information
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim("NumberPhone", user.NumberPhone),
                        new Claim("Address", user.Address),
                        new Claim("Email", user.Email),
                        new Claim("Roles", user.Roles),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var data = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(data);
                }
                else
                {

                }
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddNewUser")]
        public IActionResult AddNewUser([FromBody] UserView userView)
        {
            var u = new User();
            u.FirstName = userView.FirstName;
            u.LastName = userView.LastName;     
            u.NumberPhone = userView.NumberPhone;
            u.Address = userView.Address;
            u.Email = userView.Email;
            u.Passwork = userView.PassWork;
           /* u.Roles = userView.Roles;*/
            MailContent content = new MailContent
            {
                To = u.Email,
                Subject = "Create Account!",
                Body = "<div><strong>Thank you for registering an account at our store.</strong><br><p>Please access your account at http://fftmobile.vn/account to place orders and manage transactions more quickly and conveniently.</p><p>Visit the store to continue shopping with us Visit the store to continue shopping with us</p></div>"
            };
        
            _userService.AddNewUser(u);
            _userService.Save();
            _sendMailService.SendMail(content);
            return NoContent();
        }

        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var product = _userService.GetUserById(id);
            return Ok(product);
        }
        [HttpPut("EditUser/{id}")]
        public IActionResult EditUser(int id,[FromBody] UserView userView)
        {
            var item = _userService.GetUserById(id);
            if(item == null)
            {
                return BadRequest();
            }
            item.FirstName = userView.FirstName;
            item.LastName = userView.LastName;
            item.NumberPhone = userView.NumberPhone;
            item.Address = userView.Address;
            item.Email = userView.Email;
            item.Passwork = userView.PassWork;
            /*item.StatusUserId = userView.StatusUserId;*/
            _userService.UpdateUser(item);
            _userService.Save();
            return Ok();
        }
        [HttpPut("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingItem = _userService.GetUserById(id);
            if (existingItem == null) return BadRequest();
            _userService.ChangeIsDelete(existingItem);
            return Ok();
        }
        [HttpPatch("ChangeStatus/{id}")]
        public IActionResult ChangeStatusUser(int id)
        {
            var existingItem = _userService.GetUserById(id);
            if (existingItem == null) return BadRequest();
            _userService.ChangeStatus(existingItem);
            return Ok();
        }

        [HttpPost("CreateOrder")]
        public  IActionResult CreateOrder([FromBody]OrderView orderView)
        {
            if (orderView != null)
            {
                var ord = new Order();
                ord.Price = orderView.Price;
                ord.UserId = orderView.UserId;
                ord.Quantity = orderView.Quantity;
                _orderService.CreateOrder(ord);
                _orderService.SaveOrder();
               
                //1 Order : detail by quantity subproduct
                for(int i = 0;i < ord.Quantity;++i)
                {
                    var priceProduct = _productService.GetProductById(orderView.ProductId);
                    var subProduct = _subproductService.GetSubByProId(orderView.ProductId);
                    if (subProduct != null)
                    {
                        var detail = new DetailOrder();

                        detail.OrderId = ord.OrderId;
                        detail.SubProductId = subProduct.SubProductId;
                        detail.Price = priceProduct.Price;

                        //change status SubProduct
                        subProduct.StatusId = 2;
                        _subproductService.UpdateSubProduct(subProduct);
                        _detailOrderService.CreateDetailOrd(detail);
                        _detailOrderService.Save();
                      
                    }
                    else
                    {
                        return BadRequest("San Pham Da Het!");
                    }
                }
                return Ok();
              
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOrderByUserId")]
        public IEnumerable<Order> GetOrderByUserId(int userId)
        {
           /* if (userId != null)
            {*/
              var ord =  _orderService.getOrderByUserId(userId);
                foreach (var or in ord)
                {
                    yield return or;
                }
          /*  } */
        }

        [HttpGet("GetListOrderAdmin")]
        public IEnumerable<Order> GetListOrder(int id)
        {
          /*  if (id != null)
            {*/
                var ord = _orderService.getListOrderByStatus(id);
                foreach (var or in ord)
                {
                    yield return or;
                }
       /*     }
            else
                return BadRequest();*/
        }
        [HttpGet("ChangeStatusOrder")]
        public IActionResult ChangeStatusOrder(int OrderId)
        {
           var order =   _orderService.GetOrderByOrderId(OrderId);
            if(order == null)
            {
                return BadRequest();
            }
            else
            {
                _orderService.UpdateOrder(order);
                _orderService.SaveOrder();
                return Ok();
            }
        }
        [HttpGet("GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
          /*  if (id != null)
            {*/
                var item = _orderService.GetOrderByOrderId(id);
                return Ok(item);
          /*  }
            else
                return BadRequest();*/
        }
        /// <summary>
        /// Get Count Subproduct with status = 1  (Active)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("CountSubProduct")]
        public IActionResult CountSubProduct(int id)
        {
          /*  if (id != null)
            {*/
                var items =  _subproductService.CountSubOfProductId(id);
                return Ok(items.Count());
            /*}
            else
                return BadRequest();*/
        }
    }
}

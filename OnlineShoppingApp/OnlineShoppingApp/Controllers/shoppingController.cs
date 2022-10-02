using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Models;
using OnlineShoppingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class shoppingController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IProductService _ProductService;
        public shoppingController(IProductService ProductService, IUserService UserService)
        {
            _ProductService = ProductService;
            _UserService = UserService;
        }

        /// <summary>
        /// Here We are Registering the user
        /// I always takes  the Unique username and email 
        /// if you same username and email which exist it thorow error
        /// we dont have to pass the  id i will automatically created by the mongodb
        /// </summary>
        /// <param name="user">User Data</param>
        /// <returns>gives  msg user registeration </returns>
        [HttpPost]
        [Route("[action]")]
        public ActionResult<User> register([FromBody] User user)
        {
            var data = _UserService.Register(user);
            if (data == null)
            {
                return NotFound("Users with same Email and UserName are Exist");

            }
            else
            {
                return Ok("Acoount Created Successfully");
            }

        }

        /// <summary>
        /// it is used to log in if we give the coreect username and password
        /// it will make us log in and we will recive the user details
        /// </summary>
        /// <param name="username">username at the time registeration</param>
        /// <param name="password"> password at the registeration</param>
        /// <returns>the user details</returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult login(string username, string password)
        {
            User data = _UserService.login(username, password);

            if (data != null)
            {
                return Ok(data);
            }
            return Unauthorized("Invalid Credentials");
        }

        /// <summary>
        /// we can update the password here
        /// </summary>
        /// <param name="username"> username must be exist </param>
        /// <param name="password">new password</param>
        /// <returns>updated message</returns>
        [HttpGet]
        [Route("{customername}/[action]")]
        public IActionResult forgot(string customername, string password)
        {

            if (!_UserService.UpdatePassword(customername, password))
            {
                return NotFound("UserName does not exist");
            }


            return Ok("Password is Updated Successfully");
        }


        /// <summary>
        ///Get All Product 
        /// </summary>
        /// <returns>Products List</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult all()
        {
            return Ok(_ProductService.GetAll());
        }

        /// <summary>
        /// searching user
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>user</returns>

        [Route("product/[action]/productname")]
        [HttpGet]
        public IActionResult search(string productname)
        {
            var data = _ProductService.SearchProduct(productname);
            if (data == null)
            {
                return NotFound("Product is Not Found");

            }
            else
            {
                return Ok(data);
            }

        }

        /// <summary>
        /// here add a product
        /// </summary>
        /// <param name="productname">productname</param>
        /// <param name="product">ProductData
        /// </param>
        /// <returns> Product added msg</returns>
        [HttpPost]
        [Route("{productname}/[action]")]
        public ActionResult<Product> add(string productname, [FromBody] Product product)
        {
            _ProductService.AddProduct(productname, product);
            return Ok("Product Added Successfully");

        }

        /// <summary>
        /// we can update the Product here
        /// </summary>
        /// <param name="username"></param>
        /// <param name="id"> tweetid</param>
        /// <param name="tweet"> update tweet</param>
        /// <returns>msg</returns>
        [HttpPut]
        [Route("{productname}/[action]/{id}")]
        public IActionResult update(string productname, int id, Product product)
        {

            if (!_ProductService.UpdateProduct(productname, id, product))
            {
                return NotFound("Product Name or Product Id does not exist");
            }


            return Ok("Product is Updated Successfully");
        }
        /// <summary>
        /// we can delete the Product here
        /// </summary>
        /// <param name="productname">productname</param>
        /// <param name="id">Product id</param>
        /// <returns> meassage</returns>
        [HttpDelete]
        [Route("{productname}/[action]/{id}")]
        public IActionResult delete(string productname, int id)
        {

            if (!_ProductService.DeleteProduct(productname, id))
            {
                return NotFound("Product Name or Product Id does not exist");
            }


            return Ok("Product is Deleted Successfully");
        }

    }
}

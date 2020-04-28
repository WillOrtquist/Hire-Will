using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;
using SampleApi.Models.Account;
using SampleApi.Providers.Security;

namespace SampleApi.Controllers
{
    /// <summary>
    /// Creates a new order controller to save order details
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderDAO orderDao;

        
        public OrderController(IOrderDAO orderDao)
        {
            this.orderDao = orderDao;
        }


        [HttpGet("getAllOrders")]
        public List <Order> GetAllOrders()
        {
            return orderDao.GetAllOrders();
        }
        /// <summary>
        /// Creates a new order in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpPost("cakeOrder")]
        public IActionResult Create([FromBody] Order order)
        {
            int id = orderDao.AddOrder(order);
            return Ok(id);

        }
        /// <summary>
        /// Updates order status
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("updateOrderStatus")]
        public IActionResult UpdateCakeAvailability([FromBody] Order order)
        {
            bool result = false;
            if (orderDao.UpdateOrderStatus(order))
            {
                result = true;
            }
            return Ok(result);
        }

        //[HttpGet( "{id}", Name ="getOrder")]
        [HttpGet("getOrder/{id}")]
        public Order GetOrder(int id)
        {
            return orderDao.GetOrder(id);
        }
    }
}
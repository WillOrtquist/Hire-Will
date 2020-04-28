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
    /// Creates a new cake controller used to get a list of cakes/create new cake
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private ICakeInfoDAO cakeDao;

        
        public CakeController(ICakeInfoDAO cakeDao)
        {
            this.cakeDao = cakeDao;
        }

        [HttpGet("getAll")]
        public List<Cake> GetAllCakes()
        {
            return cakeDao.GetAllCakes();
        }

        //[HttpGet( "{id}", Name ="getCake")]
        [HttpGet("getCake/{id}")]
        public Cake GetCake(int id)
        {
            return cakeDao.GetCake(id);
        }


        /// <summary>
        /// Creates a new standard cake in the database
        /// </summary>
        /// <param name="cake"></param>
        /// <returns></returns>
        [HttpPost("newCake")]
        public IActionResult Create([FromBody] Cake cake)
        {
            bool result=false;
            if (cakeDao.AddCake(cake))
            {
               result = true;
            }
            return Ok(result);
        }
        /// <summary>
        /// Updates availablity of standard cake in the database
        /// </summary>
        /// <param name="cake"></param>
        /// <returns></returns>
        [HttpPost("updateAvailable")]
        public IActionResult UpdateCakeAvailability([FromBody] Cake cake)
        {
            bool result = false;
            if (cakeDao.UpdateCakeAvailability(cake))
            {
                result = true;
            }
            return Ok(result);
        }
    }
}
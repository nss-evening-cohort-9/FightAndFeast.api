using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FightAndFeast.Models;
using FightAndFeast.DataAccess;

namespace FightAndFeast.Controllers
{
    [Route("api/sellers")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        // GET: api/Seller
        [HttpGet]
        public IEnumerable<Seller> GetSellers()
        {
            var repo = new SellerRepository();
            return repo.GetAll();
        }

        // GET: api/Seller/5
        [HttpGet("{name}")]
        public ActionResult<Seller> GetSeller(string name)
        {
            var repo = new SellerRepository();
            return repo.Get(name);
           
        }

        // POST: api/Seller
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Seller/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

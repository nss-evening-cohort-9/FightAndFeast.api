using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FightAndFeast.Models;
using FightAndFeast.DataAccess;
using FightAndFeast.Controllers;

namespace FightAndFeast.Controllers
{
    [Route("api/clubs")]
    [ApiController]
    public class ClubController : ControllerBase
    {        
        [HttpGet]
        public IEnumerable<Club> GetClubs()
        {
            var repo = new ClubRepository();
            return repo.GetAll();

        }
                
        [HttpGet("{name}")]
        public ActionResult<Club> GetClub(string name)
        {
            var repo = new ClubRepository();
            return repo.GetClub(name);
        }

        // POST: api/Club
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Club/5
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

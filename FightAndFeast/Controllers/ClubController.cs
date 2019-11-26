using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FightAndFeast.Models;
using FightAndFeast.DataAccess;
using FightAndFeast.Commands;

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
        
        [HttpPost]
        public void AddClub(AddClubCommand newClub)
        {
            var repo = new ClubRepository();
            repo.AddClub(newClub);
        }
                
        [HttpPut("{id}")]
        public void UpdateClub(UpdateClubCommand updatedClubCommand, int id)
        {
            var repo = new ClubRepository();

            var updatedClub = new Club
            {
                Name = updatedClubCommand.Name,
                Address = updatedClubCommand.Address,
                Phone = updatedClubCommand.Phone,
                Capacity = updatedClubCommand.Capacity,
                Description = updatedClubCommand.Description
            };

            repo.UpdateClub(updatedClub, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

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
    [Route("api/sellers")]
    [ApiController]
    public class SellerController : ControllerBase
    {       
        [HttpGet]
        public IEnumerable<Seller> GetSellers()
        {
            var repo = new SellerRepository();
            return repo.GetAll();
        }
       
        [HttpGet("{name}")]
        public ActionResult<Seller> GetSeller(string name)
        {
            var repo = new SellerRepository();
            return repo.Get(name);
           
        }
        
        [HttpPost]
        public void AddSeller(AddSellerCommand newSeller)
        {
            var repo = new SellerRepository();
            repo.AddSeller(newSeller);
        }
        
        [HttpPut("{id}")]
        public void UpdateSeller(UpdateSellerCommand updatedSellerCommand, int id)
        {
            var repo = new SellerRepository();

            var updatedSeller = new Seller
            {
                Name = updatedSellerCommand.Name
            };

            repo.UpdateSeller(updatedSeller, id);
        }
        
        [HttpDelete("{id}")]
        public void DeleteSeller(UpdateSellerCommand updatedSellerCommand, int id)
        {
            var repo = new SellerRepository();

            var deletedSeller = new Seller
            {
                Name = updatedSellerCommand.Name
            };

            repo.DeleteSeller(deletedSeller, id);
        }
    }
}

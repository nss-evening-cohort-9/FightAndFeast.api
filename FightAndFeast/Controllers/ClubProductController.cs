using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Commands;
using FightAndFeast.DataAccess;
using FightAndFeast.Dtos;
using FightAndFeast.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FightAndFeast.Controllers
{
    [Route("api/clubProducts")]
    [ApiController, Authorize]
    public class ClubProductController : ControllerBase
    {
        // GET: api/clubProducts
        [HttpGet]
        public IEnumerable<ClubProductDto> GetAll()
        {
            var repo = new ClubProductRepository();
            return repo.GetAllClubProducts();
        }

        // GET: api/clubProducts/1
        [HttpGet("{clubProductId}")]
        public ClubProductDto Get(int clubProductId)
        {
            var repo = new ClubProductRepository();
            return repo.GetClubProduct(clubProductId);
        }

        // GET: api/clubProducts/recent/
        [HttpGet("recent")]
        public IEnumerable<ClubProductDto> GetRecent()
        {
            var repo = new ClubProductRepository();
            var products = repo.GetRecentClubProducts();
            return products;
        }

        // POST: api/clubProducts
        [HttpPost]
        public void Create(AddClubProductCommand newClubProduct)
        {
            var repo = new ClubProductRepository();
            repo.AddClubProduct(newClubProduct);
        }

        // PUT: api/clubProducts/5
        [HttpPut("{id}")]
        public void Update(UpdateClubProductCommand updatedClubProductCommand, int id)
        {
            var repo = new ClubProductRepository();
            var updatedClubProduct = new ClubProduct
            {
                ClubId = updatedClubProductCommand.ClubId,
                ProductId = updatedClubProductCommand.ProductId,
            };
            repo.UpdateClubProduct(updatedClubProduct, id);
        }

        // DELETE: api/clubProducts/5
        [HttpDelete("{id}")]
        public void Delete(UpdateClubProductCommand updatedClubProductCommand, int id)
        {
            var repo = new ClubProductRepository();
            var updatedClubProduct = new ClubProduct
            {
                ClubId = updatedClubProductCommand.ClubId,
                ProductId = updatedClubProductCommand.ProductId,
            };
            repo.DeleteClubProduct(updatedClubProduct, id);
        }
    }
}

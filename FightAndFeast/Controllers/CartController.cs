using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Commands;
using FightAndFeast.DataAccess;
using FightAndFeast.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FightAndFeast.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/carts
        [HttpGet]
        public IEnumerable<Cart> GetAll()
        {
            var repo = new CartRepository();
            return repo.GetAllCarts();
        }

        // GET: api/carts/1
        [HttpGet("{cartId}")]
        public Cart Get(int cartId)
        {
            var repo = new CartRepository();
            return repo.GetCart(cartId);
        }

        // POST: api/carts
        [HttpPost]
        public void Create(AddCartCommand newCart)
        {
            var repo = new CartRepository();
            repo.AddCart(newCart);
        }

        // DELETE: api/carts/5
        [HttpPut("{id}")]
        public void Update(UpdateCartCommand updatedCartCommand, int id)
        {
            var repo = new CartRepository();
            var updatedCart = new Cart
            {
                Total = updatedCartCommand.Total,
            };
            repo.UpdateCart(updatedCart, id);
        }

        // DELETE: api/carts/5
        [HttpDelete("{id}")]
        public void Delete(Cart cartToDelete, int id)
        {
            var repo = new CartRepository();
            repo.DeleteCart(cartToDelete, id);
        }
    }
}

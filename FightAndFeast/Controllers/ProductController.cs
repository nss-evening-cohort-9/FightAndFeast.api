using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FightAndFeast.DataAccess;
using FightAndFeast.Models;
using FightAndFeast.Commands;

namespace FightAndFeast.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var repo = new ProductRepository();
            var products = repo.GetAll();
            return products;
        }

        // GET: api/products/5
        [HttpGet("{productid}")]
        public Product GetProduct(int productId)
        {
            var repo = new ProductRepository();
            var product = repo.Get(productId);
            return product;
        }

        // POST: api/Product
        [HttpPost]
        public void AddProduct(AddProductCommand newProduct)
        {
            var repo = new ProductRepository();
            repo.AddProduct(newProduct);
        }



        // PUT: api/Product/5
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

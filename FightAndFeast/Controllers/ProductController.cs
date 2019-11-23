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
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var repo = new ProductRepository();
            var products = repo.GetAll();
            return products;
        }

        // GET: api/Product/5

        [HttpGet("{productid}")]
        public Product GetProduct(int productId)
        {
            var repo = new ProductRepository();
            var product = repo.Get(productId);
            return product;
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct(AddProductCommand newProductCommand)
        {
            var newProduct = new Product
            {
                Id = 1,
                Name = newProductCommand.Name,
                TypeId = newProductCommand.TypeId,
                Price = newProductCommand.Price,
                Description = newProductCommand.Description
            };

            var repo = new ProductRepository();
            var productThatGotCreated = repo.Add(newProduct);

            return Created($"api/products/{productThatGotCreated.Name}", productThatGotCreated);



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

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
        public IEnumerable<Product> GetAll()
        {
            var repo = new ProductRepository();
            var products = repo.GetAllProducts();
            return products;
        }

        // GET: api/products/5
        [HttpGet("{productId}")]
        public Product Get(int productId)
        {
            var repo = new ProductRepository();
            var product = repo.GetProduct(productId);
            return product;
        }

        // POST: api/products/
        [HttpPost]
        public void Create(AddProductCommand newProduct)
        {
            var repo = new ProductRepository();
            repo.AddProduct(newProduct);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public void Update(UpdateProductCommand updatedProductCommand, int id)

        {
            var repo = new ProductRepository();
            var updatedProduct = new Product
            {
                Name = updatedProductCommand.Name,
                TypeId = updatedProductCommand.TypeId,
                Price = updatedProductCommand.Price,
                Description = updatedProductCommand.Description
            };
            repo.UpdateProduct(updatedProduct, id);

        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public void Delete(UpdateProductCommand updatedProductCommand, int id)
        {
            var repo = new ProductRepository();
            var deletedProduct = new Product
            {
                Name = updatedProductCommand.Name,
                TypeId = updatedProductCommand.TypeId,
                Price = updatedProductCommand.Price,
                Description = updatedProductCommand.Description,
            };
            repo.DeleteProduct(deletedProduct, id);
        }
    }
}

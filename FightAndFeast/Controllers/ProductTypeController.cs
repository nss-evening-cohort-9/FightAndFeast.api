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
    [Route("api/productTypes")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        // GET: api/productTypes
        [HttpGet]
        public IEnumerable<ProductType> GetAll()
        {
            var repo = new ProductTypeRepository();
            return repo.GetAllProductTypes();
        }

        // GET: api/productTypes/1
        [HttpGet("{productTypeId}")]
        public ProductType Get(int productTypeId)
        {
            var repo = new ProductTypeRepository();
            return repo.GetProductType(productTypeId);
        }

        // POST: api/productTypes
        [HttpPost]
        public void Create(AddProductTypeCommand newProductType)
        {
            var repo = new ProductTypeRepository();
            repo.AddProductType(newProductType);
        }

        // PUT: api/productTypes/5
        [HttpPut("{id}")]
        public void Update(UpdateProductTypeCommand updatedProductTypeCommand, int id)
        {
            var repo = new ProductTypeRepository();
            var updatedProductType = new ProductType
            {
                Name = updatedProductTypeCommand.Name,
            };
            repo.UpdateProductType(updatedProductType, id);
        }

        // DELETE: api/productTypes/5
        [HttpDelete("{id}")]
        public void Delete(UpdateProductTypeCommand updatedProductTypeCommand, int id)
        {
            var repo = new ProductTypeRepository();
            var updatedProductType = new ProductType
            {
                Name = updatedProductTypeCommand.Name,
            };
            repo.DeleteProductType(updatedProductType, id);
        }
    }
}

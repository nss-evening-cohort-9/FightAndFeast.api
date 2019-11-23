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
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            var repo = new CustomerRepository();
            return repo.GetAllCustomers();
        }

        // GET: api/customers/1
        [HttpGet("{customerId}")]
        public Customer Get(int customerId)
        {
            var repo = new CustomerRepository();
            return repo.GetCustomer(customerId);
        }

        // POST: api/customer
        [HttpPost]
        public void Create(AddCustomerCommand newCustomer)
        {
            var repo = new CustomerRepository();
            repo.AddCustomer(newCustomer);
        }

        // PUT: api/customer/5
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

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

        // POST: api/customers
        [HttpPost]
        public void Create(AddCustomerCommand newCustomer)
        {
            var repo = new CustomerRepository();
            repo.AddCustomer(newCustomer);
        }

        // DELETE: api/customers/5
        [HttpPut("{id}")]
        public void Update(UpdateCustomerCommand updatedCustomerCommand, int id)
        {
            var repo = new CustomerRepository();
            var updatedCustomer = new Customer
            {
                FirstName = updatedCustomerCommand.FirstName,
                LastName = updatedCustomerCommand.LastName,
                HasFought = updatedCustomerCommand.HasFought,
                Email = updatedCustomerCommand.Email,
                Phone = updatedCustomerCommand.Phone,
            };
            repo.UpdateCustomer(updatedCustomer, id);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public void Delete(UpdateCustomerCommand updatedCustomerCommand, int id)
        {
            var repo = new CustomerRepository();
            var updatedCustomer = new Customer
            {
                FirstName = updatedCustomerCommand.FirstName,
                LastName = updatedCustomerCommand.LastName,
                Email = updatedCustomerCommand.Email,
                Phone = updatedCustomerCommand.Phone,
            };
            repo.DeleteCustomer(updatedCustomer, id);
        }
    }
}

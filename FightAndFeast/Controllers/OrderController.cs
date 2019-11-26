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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/orders
        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            var repo = new OrderRepository();
            return repo.GetAllOrders();
        }

        // GET: api/orders/1
        [HttpGet("{orderId}")]
        public Order Get(int orderId)
        {
            var repo = new OrderRepository();
            return repo.GetOrder(orderId);
        }

        // POST: api/orders
        [HttpPost]
        public void Create(AddOrderCommand newOrder)
        {
            var repo = new OrderRepository();
            repo.AddOrder(newOrder);
        }

        // PUT: api/orders/5
        [HttpPut("{id}")]
        public void Update(UpdateOrderCommand updatedOrderCommand, int id)
        {
            var repo = new OrderRepository();
            var updatedOrder = new Order
            {
                CustomerId = updatedOrderCommand.CustomerId,
                Total = updatedOrderCommand.Total,
                CustomerPaymentTypeId = updatedOrderCommand.CustomerPaymentTypeId,
            };
            repo.UpdateOrder(updatedOrder, id);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public void Delete(UpdateOrderCommand updatedOrderCommand, int id)
        {
            var repo = new OrderRepository();
            var updatedOrder = new Order
            {
                CustomerPaymentTypeId = updatedOrderCommand.CustomerPaymentTypeId,
            };
            repo.DeleteOrder(updatedOrder, id);
        }
    }
}

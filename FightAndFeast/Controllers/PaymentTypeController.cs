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
    [Route("api/paymentTypes")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        // GET: api/paymentTypes
        [HttpGet]
        public IEnumerable<PaymentType> GetAll()
        {
            var repo = new PaymentTypeRepository();
            return repo.GetAllPaymentTypes();
        }

        // GET: api/paymentTypes/1
        [HttpGet("{paymentTypeId}")]
        public PaymentType Get(int paymentTypeId)
        {
            var repo = new PaymentTypeRepository();
            return repo.GetPaymentType(paymentTypeId);
        }

        // POST: api/paymentTypes
        [HttpPost]
        public void Create(AddPaymentTypeCommand newPaymentType)
        {
            var repo = new PaymentTypeRepository();
            repo.AddPaymentType(newPaymentType);
        }

        // PUT: api/paymentTypes/5
        [HttpPut("{id}")]
        public void Update(UpdatePaymentTypeCommand updatedPaymentTypeCommand, int id)
        {
            var repo = new PaymentTypeRepository();
            var updatedPaymentType = new PaymentType
            {
                Name = updatedPaymentTypeCommand.Name,
            };
            repo.UpdatePaymentType(updatedPaymentType, id);
        }

        // DELETE: api/paymentTypes/5
        [HttpDelete("{id}")]
        public void Delete(UpdatePaymentTypeCommand updatedPaymentTypeCommand, int id)
        {
            var repo = new PaymentTypeRepository();
            var updatedPaymentType = new PaymentType
            {
                Name = updatedPaymentTypeCommand.Name,
            };
            repo.DeletePaymentType(updatedPaymentType, id);
        }
    }
}

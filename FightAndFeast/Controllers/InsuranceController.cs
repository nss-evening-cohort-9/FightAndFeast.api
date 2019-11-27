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
    [Route("api/insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        // GET: api/insurance
        [HttpGet]
        public IEnumerable<Insurance> GetAll()
        {
            var repo = new InsuranceRepository();
            return repo.GetAllInsurance();
        }

        // GET: api/insurance/1
        [HttpGet("{insuranceId}")]
        public Insurance Get(int insuranceId)
        {
            var repo = new InsuranceRepository();
            return repo.GetInsurance(insuranceId);
        }

        // POST: api/insurance
        [HttpPost]
        public void Create(AddInsuranceCommand newInsurance)
        {
            var repo = new InsuranceRepository();
            repo.AddInsurance(newInsurance);
        }

        // PUT: api/insurance/5
        [HttpPut("{id}")]
        public void Update(UpdateInsuranceCommand updatedInsuranceCommand, int id)
        {
            var repo = new InsuranceRepository();
            var updatedInsurance = new Insurance
            {
                Provider = updatedInsuranceCommand.Provider,
                TypeId = updatedInsuranceCommand.TypeId,
            };
            repo.UpdateInsurance(updatedInsurance, id);
        }

        // DELETE: api/insurance/5
        [HttpDelete("{id}")]
        public void Delete(UpdateInsuranceCommand updatedInsuranceCommand, int id)
        {
            var repo = new InsuranceRepository();
            var updatedInsurance = new Insurance
            {
                Provider = updatedInsuranceCommand.Provider,
                TypeId = updatedInsuranceCommand.TypeId,
            };
            repo.DeleteInsurance(updatedInsurance, id);
        }
    }
}

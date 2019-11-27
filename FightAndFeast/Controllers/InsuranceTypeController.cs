using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FightAndFeast.Models;
using FightAndFeast.DataAccess;
using FightAndFeast.Controllers;
using FightAndFeast.Commands;

namespace FightAndFeast.Controllers
{
    [Route("api/insuranceTypes")]
    [ApiController]
    public class InsuranceTypeController : ControllerBase
    {        
        [HttpGet]
        public IEnumerable<InsuranceType> Get()
        {
            var repo = new InsuranceTypeRepository();
            return repo.GetAllInsuranceTypes();
        }
               
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var repo = new InsuranceTypeRepository();
            return repo.GetInsuranceType(id);
        }

        // POST: api/InsuranceType
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InsuranceType/5
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

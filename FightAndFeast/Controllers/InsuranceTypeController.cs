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
        public ActionResult<InsuranceType> Get(int id)
        {
            var repo = new InsuranceTypeRepository();
            return repo.GetInsuranceType(id);
        }
                
        [HttpPost]
        public void AddNewInsuranceType(AddInsuranceTypeCommand newInsuranceType)
        {
            var repo = new InsuranceTypeRepository();
            repo.AddInsuranceType(newInsuranceType);
        }
                
        [HttpPut("{id}")]
        public void UpdateInsuranceType(UpdateInsuranceTypeCommand updatedInsuranceTypeCommand, int id)
        {
            var repo = new InsuranceTypeRepository();

            var updatedInsuranceType = new InsuranceType
            {
                Name = updatedInsuranceTypeCommand.Name
            };

            repo.UpdateInsuranceType(updatedInsuranceType, id);
        }
                
        [HttpDelete("{id}")]
        public void DeleteInsuranceType(UpdateInsuranceTypeCommand deletedInsuranceTypeCommand, int id)
        {
            var repo = new InsuranceTypeRepository();

            var deletedInsuranceType = new InsuranceType
            {
                Name = deletedInsuranceTypeCommand.Name
            };

            repo.DeleteInsuranceType(deletedInsuranceType, id);
        }
    }
}

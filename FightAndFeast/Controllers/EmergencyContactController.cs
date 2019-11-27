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
    [Route("api/emergencyContacts")]
    [ApiController]
    public class EmergencyContactController : ControllerBase
    {
        // GET: api/emergencycontacts
        [HttpGet]
        public IEnumerable<EmergencyContact> GetAll()
        {
            var repo = new EmergencyContactRepository();
            var emergencycontacts = repo.GetAllEmergencyContacts();
            return emergencycontacts;
        }
       

        // GET: api/emergencycontacts/5
        [HttpGet("{EmergencyContactId}")]
        public EmergencyContact Get(int emergencycontactId)
        {
            var repo = new EmergencyContactRepository();
            var emergencycontact = repo.GetEmergencyContact(emergencycontactId);
            return emergencycontact;
        }

        // POST: api/EmergencyContacts/
        [HttpPost]
        public void Create(AddEmergencyContactCommand newEmergencyContact)
        {
            var repo = new EmergencyContactRepository();
            repo.AddEmergencyContact(newEmergencyContact);
        }


        // PUT: api/EmergencyContacts/5
        [HttpPut("{id}")]
        public void Update(UpdateEmergencyContactCommand updatedEmergencyContactCommand, int id)

        {
            var repo = new EmergencyContactRepository();
            var updatedEmergencyContact = new EmergencyContact
            {
                FirstName = updatedEmergencyContactCommand.FirstName,
                LastName = updatedEmergencyContactCommand.LastName,
                Relationship = updatedEmergencyContactCommand.Relationship,
                Phone = updatedEmergencyContactCommand.Phone
            };
            repo.UpdateEmergencyContact(updatedEmergencyContact, id);

        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(UpdateEmergencyContactCommand updatedEmergencyContactCommand, int id)
        {
            var repo = new EmergencyContactRepository();
            var deletedEmergencyContact = new EmergencyContact
            {
                FirstName = updatedEmergencyContactCommand.FirstName,
                LastName = updatedEmergencyContactCommand.LastName,
                Relationship = updatedEmergencyContactCommand.Relationship,
                Phone = updatedEmergencyContactCommand.Phone,
            };
            repo.DeleteEmergencyContact(deletedEmergencyContact, id);
        }
    }
}

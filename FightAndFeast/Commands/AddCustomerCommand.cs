using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class AddCustomerCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool HasFought { get; set; } = false;
        public string Email { get; set; }
        public string Phone { get; set; }
        //public int CartId { get; set; }
    }
}

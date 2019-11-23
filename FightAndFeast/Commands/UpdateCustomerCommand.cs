using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class UpdateCustomerCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasFought { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

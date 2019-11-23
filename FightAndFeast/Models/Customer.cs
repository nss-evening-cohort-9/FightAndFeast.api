using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool HasFought { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CartId { get; set; }
    }
}

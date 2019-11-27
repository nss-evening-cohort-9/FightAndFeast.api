using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public int TypeId { get; set; }
    }
}

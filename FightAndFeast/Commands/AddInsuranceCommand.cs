using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class AddInsuranceCommand
    {
        public string Provider { get; set; }
        public int TypeId { get; set; }
    }
}

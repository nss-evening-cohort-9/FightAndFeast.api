using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class UpdateInsuranceCommand
    {
        public string Provider { get; set; }
        public int TypeId { get; set; }
    }
}

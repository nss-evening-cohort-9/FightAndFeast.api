using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class UpdateProductCommand
    {
              public string Name { get; set; }
              public int TypeId { get; set; }
              public decimal Price { get; set; }
              public string Description { get; set; }

    }
}


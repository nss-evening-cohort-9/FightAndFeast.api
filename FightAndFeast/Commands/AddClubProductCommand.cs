using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class AddClubProductCommand
    {
        public int ClubId { get; set; }
        public int ProductId { get; set; }
    }
}

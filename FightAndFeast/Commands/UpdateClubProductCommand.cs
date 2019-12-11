using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class UpdateClubProductCommand
    {
        public int ClubId { get; set; }
        public int ProductId { get; set; }
    }
}

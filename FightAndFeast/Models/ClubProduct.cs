﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Models
{
    public class ClubProduct
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int ProductId { get; set; }
    }
}

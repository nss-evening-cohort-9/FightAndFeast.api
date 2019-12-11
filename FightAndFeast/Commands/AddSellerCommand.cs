﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class AddSellerCommand
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public string FirebaseUid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Commands
{
    public class AddOrderCommand
    {
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public int CustomerPaymentTypeId { get; set; }
    }
}

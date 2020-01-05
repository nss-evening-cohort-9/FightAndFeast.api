using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.Dtos
{
    public class ClubProductDto
    {
        public int ClubProductId { get; set; }
        public string ClubName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EventDate { get; set; }
        public int TypeId { get; set; }
    }
}

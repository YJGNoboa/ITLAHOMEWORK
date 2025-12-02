using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string Name { get; set; }
        public decimal Discount { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

    }
}

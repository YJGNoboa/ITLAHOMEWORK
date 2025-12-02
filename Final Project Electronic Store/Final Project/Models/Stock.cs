using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CurrentQuantity { get; set; }
        public int MinimumQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

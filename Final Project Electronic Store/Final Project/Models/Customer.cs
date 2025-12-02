using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone {  get; set; }
        public bool PremiunCustomer { get; set; }
       
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id {Id}");
            sb.AppendLine($"Name {Name}");
            sb.AppendLine($"LasName {LastName}");
            return sb.ToString();
            
        }
    }
}

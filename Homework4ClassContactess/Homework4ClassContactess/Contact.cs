using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework4ClassContactess
{
    public class Contact
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsBestFriend { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"======= {Id} =======");
            sb.AppendLine($"Full Name: {Name} {Lastname}");
            sb.AppendLine($"Address: {Address}");
            sb.AppendLine($"Phone: {Phone}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Age: {Age}");
            sb.AppendLine($"Is Best Friend: {IsBestFriend}");
            sb.AppendLine("============================");
            return sb.ToString();
        }

    }

}

using Final_Project.Models;
using Homework4ClassContactess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Business_Logic
{
    public class CustomerRegistration
    {
        List<Customer> customers = new();

        public void newCustomer()
        {
            Customer customer = CustomerRegistrationHelper.AddNewCustomer();            
            customer.Id = customers.Count + 1;
            customers.Add(customer);
        }
    }
}

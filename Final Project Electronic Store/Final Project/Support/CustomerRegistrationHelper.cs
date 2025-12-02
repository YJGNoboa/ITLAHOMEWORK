using System.Text.RegularExpressions;
using System.Net.Mail;
using Final_Project.Models;

namespace Homework4ClassContactess.Helpers
{
    public static class CustomerRegistrationHelper
    {
        public static Customer AddNewCustomer()
        {
            string name = string.Empty;
            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine()!;
                if (string.IsNullOrEmpty(name))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (name.Length > 16)
                {
                    MessageHelper.ErrorMessage("Error, This field only admit a max 16 digits. Try again");
                    continue;
                }
                if (name.Length < 2)
                {
                    MessageHelper.ErrorMessage("Invalid Input");
                    continue;
                }
                if (Regex.IsMatch(name, @"^[a-z]+$"))
                {
                    MessageHelper.ErrorMessage("Error, This field doesn't admit numbers. Try again");
                    continue;
                }
                break;
            }

            string lastname = string.Empty;
            while (true)
            {
                Console.Write("Enter last name: ");
                lastname = Console.ReadLine()!;
                if (string.IsNullOrEmpty(lastname))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (lastname.Length > 16)
                {
                    MessageHelper.ErrorMessage("Error, This field only admit a max 16 digits. Try again");
                    continue;
                }
                if (!lastname.All(char.IsLetter))
                {
                    MessageHelper.ErrorMessage("Error, This field doesn't admit numbers. Try again");
                    continue;
                }
                break;
            }            
            string phone;
            while (true)
            {
                Console.Write("Enter Phone: ");
                phone = Console.ReadLine()!;
                if (string.IsNullOrEmpty(phone))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (phone.Length < 7 || phone.Length > 15)
                {
                    MessageHelper.ErrorMessage("This field must have min 7 digits and max 15");
                    continue;
                }
                if (Regex.IsMatch(phone, @"^[0-9()-+]+$"))
                {
                    break;
                }
                else
                {
                    MessageHelper.ErrorMessage("This field only admit numbers, parenthesis y +.");
                }
            }
           
            return new Customer
            {
                Name = name,
                LastName = lastname,
                Phone = phone,

            };
        }
    }
}






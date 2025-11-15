using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace Homework4ClassContactess.Helpers
{
    public static class ContactInputHelper
    {
        public static Contact GetContactFromUser()
        {
            string name = string.Empty;
            while (true)
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
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
                if (!name.All(char.IsLetter))
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
                lastname = Console.ReadLine();
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
            string address = string.Empty;
            while (true)
            {
                Console.Write("Enter address: ");
                address = Console.ReadLine();
                if (string.IsNullOrEmpty(address))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                break;
            }
            string phone;
            while (true)
            {
                Console.Write("Enter Phone: ");
                phone = Console.ReadLine();
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
            string email = string.Empty;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                try
                {
                    var tempEmail2 = new MailAddress(email);
                    email = tempEmail2.Address;
                    break;
                }
                catch (FormatException)
                {
                    MessageHelper.ErrorMessage("Invalid email format, Please Try Again");
                    continue;
                }
            }
            int age;
            while (true)
            {
                Console.Write("Enter age: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }

                if (int.TryParse(input, out int tempAge) && tempAge > 0 && tempAge < 120)
                {
                    age = tempAge;
                    break;
                }
                else
                {
                    MessageHelper.ErrorMessage("This field only contains numbers. Age must greater than 0 and lees than 120");
                    continue;
                }
            }
            bool isBestFriend = false;
            Console.Write("Is your best friend?");
            Console.WriteLine("1. Yes, AnyKey. No");
            string inputIsBestFriend = Console.ReadLine();
            if (inputIsBestFriend == "1")
            {
                isBestFriend = true;
            }
            else
            {
                isBestFriend = false;
            }

            return new Contact
            {
                Name = name,
                Lastname = lastname,
                Address = address,
                Phone = phone,
                Email = email,
                Age = age,
                IsBestFriend = isBestFriend,
            };
        }
      
        
            public static string GetName(string message)
            {
                string name;
                while (true)
                {
                    Console.Write(message);
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                        continue;
                    }
                    if (name.Length > 16)
                    {
                        MessageHelper.ErrorMessage("Error, Max 16 characters allowed");
                        continue;
                    }
                    if (!name.All(char.IsLetter))
                    {
                        MessageHelper.ErrorMessage("Error, Only letters allowed");
                        continue;
                    }
                    break;
                }
                return name;
            }

            public static string GetAddress()
            {
                string address;
                while (true)
                {
                    Console.Write("Enter Address: ");
                    address = Console.ReadLine();
                    if (string.IsNullOrEmpty(address))
                    {
                        MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                        continue;
                    }
                    break;
                }
                return address;
            }

            public static string GetPhone()
            {
                string phone;
                while (true)
                {
                    Console.Write("Enter Phone: ");
                    phone = Console.ReadLine();
                    if (string.IsNullOrEmpty(phone))
                    {
                        MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                        continue;
                    }
                    if (phone.Length < 7 || phone.Length > 15)
                    {
                        MessageHelper.ErrorMessage("Phone must be between 7 and 15 digits");
                        continue;
                    }
                    if (Regex.IsMatch(phone, @"^[0-9()-+]+$"))
                    {
                        break;
                    }
                    else
                    {
                        MessageHelper.ErrorMessage("Only numbers, parenthesis and + allowed");
                    }
                }
                return phone;
            }

        public static string GetEmail()
        {
            string email;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                try
                {
                    var tempEmail = new MailAddress(email);
                    email = tempEmail.Address;
                    break;
                }
                catch (FormatException)
                {
                    MessageHelper.ErrorMessage("Invalid email format, Please Try Again");
                }
            }
            return email;
        }

        public static int GetAge()
        {
            int age;
            while (true)
            {
                Console.Write("Enter Age: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (int.TryParse(input, out int tempAge) && tempAge > 0 && tempAge < 120)
                {
                    age = tempAge;
                    break;
                }
                else
                {
                    MessageHelper.ErrorMessage("Age must be between 1 and 119");
                }
            }
            return age;
        }

        public static bool GetBestFriend()
        {
            Console.Write("Is your best friend? (1 = Yes, AnyKey = No): ");
            string input = Console.ReadLine();
            return input == "1";
        }
    }
}




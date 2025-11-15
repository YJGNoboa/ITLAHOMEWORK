using Homework4ClassContactess.Helpers;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework4ClassContactess
{
    public class ContactManager
    {
        private List<Contact> contacts = new();
        

        public ContactManager()
        {
            
            SeedContacts();
        }

        private void SeedContacts()
        {
            contacts.Add(new Contact
            {
                Id = contacts.Count + 1,
                Name = "Yanel",
                Lastname = "Gonzalez",
                Address = "Azua, RD",
                Phone = "809-123-4567",
                Email = "yanel@example.com",
                Age = 21,
                IsBestFriend = true
            });

            contacts.Add(new Contact
            {
                Id = contacts.Count + 1,
                Name = "Laura",
                Lastname = "Martinez",
                Address = "Santo Domingo",
                Phone = "809-555-7890",
                Email = "laura.martinez@correo.com",
                Age = 24,
                IsBestFriend = false
            });
        }       

        public void AddContact()
        {
            Contact contact = ContactInputHelper.GetContactFromUser();
            contact.Id = contacts.Count + 1; 
            contacts.Add(contact);
            Console.WriteLine("Contact Added Succesfully");
        }
        public void ViewContacts()
        {
            if (contacts.Count <= 0)
            {
                MessageHelper.ErrorMessage("Your list does contain nothing, it's empty");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("======= Contacts List =======");
            Console.ResetColor();
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        public void SearchContactByName()
        {
            string name = string.Empty;
            int showInformation;
            while (true)
            {                
                Console.Write("Insert the name that you want to search: ");
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

                Contact found = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (found == null)
                {
                    MessageHelper.ErrorMessage("That name doesn't exist");
                    return;
                }
                else
                {
                    Console.WriteLine("The name was found\n");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine("   What do you want to do next?     ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine(" [1] Show information of this contact");
                Console.WriteLine(" [Any Key] Return to main menu");
                Console.WriteLine("====================================");
                if (int.TryParse(Console.ReadLine(), out showInformation) && showInformation == 1)
                {
                    Console.WriteLine(found);
                    
                    break;
                }
                else
                {
                    return;
                }
            }
        }
        public void ModifyContact()
        {
            bool runningRepeat = true;
            bool repeat = true;
            if (repeat)
            {
                Console.Write("Insert the Id that you want to modify: ");
            }
            while (true)
            {
                if (!repeat)
                {
                    Console.Write("Insert the id again: ");
                }
                repeat = false;
                string id = Console.ReadLine();

                if (string.IsNullOrEmpty(id))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (!int.TryParse(id, out int currentId))
                {
                    MessageHelper.ErrorMessage("This field only contains numbers");
                    continue;
                }


                Contact found = contacts.FirstOrDefault(c => c.Id == currentId);

                if (found == null)
                {
                    MessageHelper.ErrorMessage("Contact not found");
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Current contact information:");
                Console.ResetColor();
                Console.WriteLine(found);
                while (runningRepeat)
                {
                    Console.Clear();
                    Console.WriteLine("\nWhich field do you want to modify?");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Lastname");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. Phone");
                    Console.WriteLine("5. Email");
                    Console.WriteLine("6. Age");
                    Console.WriteLine("7. Is Best Friend");
                    Console.WriteLine("Any key. Cancel");

                    if (int.TryParse(Console.ReadLine(), out int option))
                    {

                        switch (option)
                        {
                            case 1:
                                found.Name = ContactInputHelper.GetName("Enter new Name: ");
                                break;
                            case 2:
                                found.Lastname = ContactInputHelper.GetName("Enter new Lastname: ");
                                break;
                            case 3:
                                found.Address = ContactInputHelper.GetAddress();
                                break;
                            case 4:
                                found.Phone = ContactInputHelper.GetPhone();
                                break;
                            case 5:
                                found.Email = ContactInputHelper.GetEmail();
                                break;
                            case 6:
                                found.Age = ContactInputHelper.GetAge();
                                break;
                            case 7:
                                found.IsBestFriend = ContactInputHelper.GetBestFriend();
                                break;
                            default:
                                Console.WriteLine("Modification cancelled.");
                                return;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nContact modified successfully!");
                        Console.ResetColor();
                        Console.WriteLine(found);
                        Console.WriteLine("Do you want to modify other field?");
                        Console.WriteLine("====================================");
                        Console.WriteLine(" [1] Yes");
                        Console.WriteLine(" [Any Key] Return to main menu");
                        if (Console.ReadLine() == "1")
                        {
                            runningRepeat = true;
                        }
                        else
                        {
                            runningRepeat = false;
                        }
                    }
                    
                }
                return;
            }
        }
                               
        public void RemoveAtContact()
        {
            bool repeat = true;
            if (repeat)
            {
                Console.Write("Insert the Id that you want to remove: ");                
            }
            while (true)
            {
                if (!repeat)
                {
                    Console.Write("Insert the id again: ");
                }
                repeat = false;
                string id = Console.ReadLine();

                if (string.IsNullOrEmpty(id))
                {
                    MessageHelper.ErrorMessage("Error, This field cannot be empty. Try again");
                    continue;
                }
                if (!int.TryParse(id, out int currentId))
                {
                    MessageHelper.ErrorMessage("This field only  contains numbers");
                    continue;
                }

                Contact foundId = contacts.FirstOrDefault(i => i.Id == currentId);

                if (foundId == null)
                {
                    MessageHelper.ErrorMessage("That contact doesn't exist");
                    return;
                }
                else
                {
                    contacts.Remove(foundId);
                    Console.WriteLine("The contact was remove sucessfully");
                    break;
                }
            }


        }        
    }
}


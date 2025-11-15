//Yanel Josias Gonzalez Noboa 20250908
using System;
using System.Net.Mail;
using Homework4ClassContactess;
using Homework4ClassContactess.Helpers;

namespace Homework4ClassContactess
{
    public class Interfaces
    {
        static void Main()
        {
            ContactManager manager = new ContactManager();
            bool goesOn = true;
            byte option;
            while (goesOn)
            {

                do
                {
                    while (true)
                    {
                        ShowOptionHelper.ShowOptionOfTheProgram();

                        if (byte.TryParse(Console.ReadLine(), out option) && option > 0 && option < 7)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            MessageHelper.ErrorMessage("Invalid Input");
                            Console.WriteLine("Press any key for try again");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    switch (option)
                    {
                        case 1:
                            {
                                manager.AddContact();
                                MessageHelper.ReturnMenuMessage();
                                break;
                            }
                        case 2:
                            {
                                manager.ViewContacts();
                                MessageHelper.ReturnMenuMessage();
                                break;
                            }
                        case 3:
                            {                
                                manager.SearchContactByName();
                                MessageHelper.ReturnMenuMessage();
                                break;
                            }
                        case 4:
                            manager.ModifyContact();
                            MessageHelper.ReturnMenuMessage();
                            break;

                        case 5:
                            manager.RemoveAtContact();
                            MessageHelper.ReturnMenuMessage();
                            break;


                        case 6:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("See you");
                            Console.WriteLine("Closing program...");                            
                            goesOn = false; return;
                    }


                } while (true);
            }


        }
    }

}
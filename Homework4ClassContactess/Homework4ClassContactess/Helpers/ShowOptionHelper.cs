using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4ClassContactess.Helpers
{
    static class ShowOptionHelper
    {
        public static void ShowOptionOfTheProgram()
        {
            Console.WriteLine("Select one option:");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Show contacts");
            Console.WriteLine("3. Search contacts");
            Console.WriteLine("4. Modify contact");
            Console.WriteLine("5. Remove contact");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Exit");
            Console.ResetColor();
            Console.Write("\nType option: ");
        }
    }
}

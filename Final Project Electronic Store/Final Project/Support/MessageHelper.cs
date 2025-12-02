using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4ClassContactess.Helpers
{
    public static class MessageHelper
    {
        public static void ErrorMessage(string personalizateMessageError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(personalizateMessageError);
            Console.ResetColor();
        }

        public static void ReturnMenuMessage()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Press any key for continue");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }
    }
}

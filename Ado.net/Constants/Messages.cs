using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net.Constants
{
    internal static class Messages
    {
        public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid, try again");
        public static void InputMessage(string title) => Console.WriteLine($"Input {title}");
        public static void SuccessMessage() => Console.WriteLine("Operation done succesfully");
        public static void ErrorOcuredMessage() => Console.WriteLine("Error occured, please try again");
    }
}

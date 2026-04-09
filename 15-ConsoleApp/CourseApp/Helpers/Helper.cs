using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Helpers
{
    public static class Helper
    {
        public static void Print(ConsoleColor consoleColor,string text)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    } 
}

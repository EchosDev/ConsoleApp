using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Helpers
{
    public static class Helper
    {
        public static void Print(ConsoleColor consoleColor, string text)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PlayIntro()
        {
            int E5 = 659;
            int C5 = 523;
            int G5 = 784;
            int G4 = 392;

            Console.Beep(E5, 100); Thread.Sleep(50);
            Console.Beep(E5, 100); Thread.Sleep(100);
            Console.Beep(E5, 100); Thread.Sleep(100);
            Console.Beep(C5, 100); Thread.Sleep(20);
            Console.Beep(E5, 100); Thread.Sleep(120);
            Console.Beep(G5, 100); Thread.Sleep(250);
            Console.Beep(G4, 100);
        }
        public static void ShowLoading()
        {
            Console.Clear();
            // Echos nicki üçün neon yaşılı rəng
            Console.ForegroundColor = ConsoleColor.Green;

            // "ECHOS" Nickname ASCII Art
            string logo = @"
  ______  _____  _    _   ____    _____ 
 |  ____|/ ____|| |  | | / __ \  / ____|
 | |__  | |     | |__| || |  | || (___  
 |  __| | |     |  __  || |  | | \___ \ 
 | |____| |____ | |  | || |__| | ____) |
 |______| \_____||_|  |_| \____/ |_____/ 
                                        ";

            Console.WriteLine(logo);
            Console.WriteLine("\n\t[ SYSTEM STARTING... ]");
            Console.WriteLine("\t[ WELCOME BACK, ECHOS ]\n");

            // Progress Bar Effekti
            Console.Write("\tLoading: [");
            for (int i = 0; i < 25; i++)
            {
                Console.Write("■"); // Daha müasir görünən kvadrat simvolu

                // Yüklenme sürətini səsə uyğunlaşdırmaq üçün
                if (i < 5) Thread.Sleep(150);
                else if (i < 15) Thread.Sleep(50);
                else Thread.Sleep(100);
            }
            Console.WriteLine("] 100%");

            Thread.Sleep(700);
            Console.ResetColor();
            Console.Clear();
        }
    }
}

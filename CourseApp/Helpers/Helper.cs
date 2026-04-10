using CourseAppCore.Entities;
using CourseAppRepository.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CourseApp.Helpers
{
    public static class Helper
    {
        private static string _path1 = "C:\\Users\\Classtime.PC_3_506_16\\Desktop\\APA202\\ConsoleApp\\CourseAppRepository\\Data\\GroupData.json";
        private static string _path2 = "C:\\Users\\Classtime.PC_3_506_16\\Desktop\\APA202\\ConsoleApp\\CourseAppRepository\\Data\\StudentData.json";

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

        public static void GetAllDatasFromDataBase()
        {
            using FileStream fileStream1 = new(_path1, FileMode.Open);
            using StreamReader reader1 = new(fileStream1);
            string groupDatas = reader1.ReadToEnd();

            using FileStream fileStream2 = new(_path2, FileMode.Open);
            using StreamReader reader2 = new(fileStream2);
            string studentDatas = reader2.ReadToEnd();

            List<Student> students;
            List<CourseGroup> groups;

            try
            {
                groups = JsonSerializer.Deserialize<List<CourseGroup>>(groupDatas);

            }
            catch (Exception)
            {
                groups = [];
            }

            try
            {
                students = JsonSerializer.Deserialize<List<Student>>(studentDatas);

            }
            catch (Exception)
            {
                students = [];
            }

            AppDbContext<CourseGroup>.datas = groups;
            AppDbContext<Student>.datas = students;

            Helper.Print(ConsoleColor.Green, "All Datas Readed from DataBase");
        }
    }
}

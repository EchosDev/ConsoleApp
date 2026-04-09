using CourseApp.Controllers;
using CourseApp.Helpers;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread soundThread = new Thread(Helper.PlayIntro);
            soundThread.Start();

            Helper.ShowLoading();

            GroupController groupController = new();

            Helper.Print(ConsoleColor.Cyan, "COURSE MANAGEMENT SYSTEM v1.0\n");

            while (true)
            {
                Helper.Print(ConsoleColor.Yellow, "==== MAIN MENU ====");
                Helper.Print(ConsoleColor.Yellow, "1.Course Group Menu \n2.Student Menu \n0.Exit");
            MainInput:
                Helper.Print(ConsoleColor.Blue, "Enter Your Choice");

                string choice = Console.ReadLine();

                int choiceNum;

                bool isChoice = int.TryParse(choice, out choiceNum);

                if (choiceNum == 0) break;
                if (isChoice)
                {
                    switch (choiceNum)
                    {
                        case 1:groupController.GroupMenu();break;
                        case 2: break;
                        default: Helper.Print(ConsoleColor.Red, "Please enter valid choice value"); break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter valid choice type");
                    goto MainInput;
                }
            }
        }

        public static void Wait()
        {

        }
    }
}

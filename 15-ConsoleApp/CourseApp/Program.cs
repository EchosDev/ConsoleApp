using CourseApp.Controllers;
using CourseApp.Helpers;

namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new();

            Helper.Print(ConsoleColor.Blue, "Select One Option");
            Helper.Print(ConsoleColor.Yellow, "1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group by id, \n" +
                "5 - Get all groups by teacher , 6 - Get all groups by room, 7 - Get all groups, 8 - Create Student, 9 - Update Student, \n" +
                "10- Get student  by id, 11 - Delete student,12 - Get students by age, 13 - Get all students by group id, \n" +
                "14- Search for groups by name, 15 - Search for students by name or surname.");
            while (true)
            {
                string selectedOption = Console.ReadLine();

                int selectedOptionNum;

                bool isSelectedOption = int.TryParse(selectedOption, out selectedOptionNum);

                if (isSelectedOption)
                {
                    switch (selectedOptionNum)
                    {
                        case 1:
                            groupController.CreateGroup();
                            break;
                        case 2:
                            groupController.UptadeGroup();
                            break;
                        case 3:
                            groupController.DeleteGroup();
                            break;
                        case 4:
                            groupController.GetGroupById();
                            break;
                        case 5:
                            groupController.GetGroupsByTeacher();
                            break;
                        default:
                            Helper.Print(ConsoleColor.Red, "Please enter valid option value");
                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter valid option type");
                }
            }
        }
    }
}

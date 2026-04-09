using CourseApp.Helpers;
using CourseAppCore.Entities;
using CourseAppService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        private static GroupService _groupService = new();
        public void CreateGroup()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Group Name:");
            string groupName = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Teacher:");
            string groupTeacher = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Room:");
            string groupRoom = Console.ReadLine();
            if (groupName is not null && groupTeacher is not null && groupRoom is not null)
            {
                CourseGroup courseGroup = new() { Name = groupName, Teacher = groupTeacher, Room = groupRoom };
                var createdGroup = _groupService.CreateGroup(courseGroup);
                Helper.Print(ConsoleColor.Green, $"Group has been created \nGroup Info: {createdGroup}");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid values");
            }
        }
        public void UptadeGroup()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Group Id:");
            string groupIdStr = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(groupIdStr, out groupId);

            if (isGroupId)
            {
                Helper.Print(ConsoleColor.Yellow, "If you don't want to change any value, leave it empty");
                Helper.Print(ConsoleColor.Blue, "Enter New Group Name:");
                string groupName = Console.ReadLine();

                Helper.Print(ConsoleColor.Blue, "Enter New Teacher:");
                string groupTeacher = Console.ReadLine();

                Helper.Print(ConsoleColor.Blue, "Enter New Room:");
                string groupRoom = Console.ReadLine();

                var updatedGroup = _groupService.UpdateGroup(groupId, groupName, groupTeacher, groupRoom);

                Helper.Print(ConsoleColor.Green, $"Group has been updated \nGroup Info: {updatedGroup}");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
            }
        }
        public void DeleteGroup()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Group Id:");
            string groupIdStr = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(groupIdStr, out groupId);

            if (isGroupId)
            {
                _groupService.DeleteGroup(groupId);
                Helper.Print(ConsoleColor.Green, "Group has been deleted succesfully");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
            }
        }
        public void GetGroupById()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Group Id:");
            string groupIdStr = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(groupIdStr, out groupId);

            if (isGroupId)
            {
                var findedGroup = _groupService.GetGroupById(groupId);
                if (findedGroup is not null)
                {
                    Helper.Print(ConsoleColor.Green, $"Group has been finded \nGroup Info: {findedGroup}");
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given ID");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
            }
        }
        public void GetGroupsByTeacher()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Teacher Name");
            string groupTeacher = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupTeacher))
            {
                var findedGroups = _groupService.GetAllGroupsByTeacher(groupTeacher);
                if (findedGroups.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Group has been finded \nGroup Infos:");
                    Console.WriteLine(string.Join(", ", findedGroups));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given teacher name");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please fill Teacher Name area");
            }
        }
        public void GetGroupsByRoom()
        {
            Helper.Print(ConsoleColor.Blue, "Enter Room");
            string groupRoom = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupRoom))
            {
                var findedGroups = _groupService.GetAllGroupsByRoom(groupRoom);
                if (findedGroups.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Group has been finded \nGroup Infos:");
                    Console.WriteLine(string.Join(", ", findedGroups));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given room");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please fill Room area");
            }
        }
        public void GetAllGroups()
        {
            var findedGroups = _groupService.GetAllGroups();
            if (findedGroups.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Group has been finded \nGroup Infos:");
                Console.WriteLine(string.Join(", ", findedGroups));
                Console.ResetColor();
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "No result found");
            }
        }
        public void GroupMenu()
        {
            while (true)
            {
                Helper.Print(ConsoleColor.Yellow, "=== GROUP MENU ===");
                Helper.Print(ConsoleColor.Yellow, "1 - Create, 2 - Update, 3 - Delete, 4 - GetById, " +
                "5 - Get By Teacher, 6 - Get By Room, 7 - Get All, 8 - Back to Main Menu");

                string selectedOption = Console.ReadLine();
                int selectedOptionNum;
                bool isSelectedOption = int.TryParse(selectedOption, out selectedOptionNum);

                if (isSelectedOption)
                {
                    if (selectedOptionNum == 8) break;

                    switch (selectedOptionNum)
                    {
                        case 1: CreateGroup(); break;
                        case 2: UptadeGroup(); break;
                        case 3: DeleteGroup(); break;
                        case 4: GetGroupById(); break;
                        case 5: GetGroupsByTeacher(); break;
                        case 6: GetGroupsByRoom(); break;
                        case 7: GetAllGroups(); break;
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

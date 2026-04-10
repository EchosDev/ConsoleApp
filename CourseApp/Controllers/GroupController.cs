using CourseApp.Helpers;
using CourseAppCore.Entities;
using CourseAppRepository.Data;
using CourseAppService.Services.Implementations;
using System.Text.Json;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        private static string _path = "C:\\Users\\Classtime.PC_3_506_16\\Desktop\\APA202\\ConsoleApp\\CourseAppRepository\\Data\\GroupData.json";
        private static GroupService _groupService = new();
        public void CreateGroup()
        {
        CreateGroupSection:
            Helper.Print(ConsoleColor.Blue, "Enter Group Name:");
            string groupName = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Teacher:");
            string groupTeacher = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Room:");
            string groupRoom = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupName) && !string.IsNullOrEmpty(groupTeacher) && !string.IsNullOrEmpty(groupRoom))
            {
                CourseGroup courseGroup = new() { Name = groupName, Teacher = groupTeacher, Room = groupRoom };
                var createdGroup = _groupService.CreateGroup(courseGroup);
                Helper.Print(ConsoleColor.Green, $"Group has been created \nGroup Info: {createdGroup}");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid values");
                goto CreateGroupSection;
            }
        }
        public void UptadeGroup()
        {
        GroupIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Group Id:");
            string groupIdStr = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(groupIdStr, out groupId);



            if (isGroupId)
            {
                bool isGroupIdNull = _groupService.GetGroupById(groupId) is not null ? true : false;
                if (isGroupIdNull)
                {
                    Helper.Print(ConsoleColor.Yellow, "If you don't want to change any value, leave it empty");
                    Helper.Print(ConsoleColor.Blue, "Enter New Group Name:");
                    string groupName = Console.ReadLine();

                    Helper.Print(ConsoleColor.Blue, "Enter New Teacher:");
                    string groupTeacher = Console.ReadLine();

                    Helper.Print(ConsoleColor.Blue, "Enter New Room:");
                    string groupRoom = Console.ReadLine();

                    var updatedGroup = _groupService.UpdateGroup(groupId, groupName, groupTeacher, groupRoom);

                    if (updatedGroup is not null) Helper.Print(ConsoleColor.Green, $"Group has been updated \nGroup Info: {updatedGroup}");
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter existing group id");
                    goto GroupIdInput;
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
                goto GroupIdInput;
            }
        }
        public void DeleteGroup()
        {
        GroupIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Group Id:");
            string groupIdStr = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(groupIdStr, out groupId);

            if (isGroupId)
            {
                bool isDeleteSuccesfully = _groupService.DeleteGroup(groupId);
                if (isDeleteSuccesfully) Helper.Print(ConsoleColor.Green, "Group has been deleted succesfully");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
                goto GroupIdInput;
            }
        }
        public void GetGroupById()
        {
        GroupIdInput:
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
                goto GroupIdInput;
            }
        }
        public void GetGroupsByTeacher()
        {
        GroupIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Teacher Name");
            string groupTeacher = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupTeacher))
            {
                var findedGroups = _groupService.GetAllGroupsByTeacher(groupTeacher);
                if (findedGroups.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Groups has been finded \nGroup of Infos:");
                    Console.WriteLine(string.Join("\n", findedGroups));
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
                goto GroupIdInput;
            }
        }
        public void GetGroupsByRoom()
        {
        RoomInput:
            Helper.Print(ConsoleColor.Blue, "Enter Room");
            string groupRoom = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupRoom))
            {
                var findedGroups = _groupService.GetAllGroupsByRoom(groupRoom);
                if (findedGroups.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Group has been finded \nGroup Infos:");
                    Console.WriteLine(string.Join("\n", findedGroups));
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
                goto RoomInput;
            }
        }
        public void GetAllGroups()
        {
            var findedGroups = _groupService.GetAllGroups();
            if (findedGroups.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Group has been finded \nGroup Infos:");
                Console.WriteLine(string.Join("\n", findedGroups));
                Console.ResetColor();
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "No result found");
            }
        }
        public void SearchForGroupsByName()
        {
        GroupNameInput:
            Helper.Print(ConsoleColor.Blue, "Enter Group Name");
            string groupName = Console.ReadLine();
            if (!string.IsNullOrEmpty(groupName))
            {
                var findedGroups = _groupService.SearchByName(groupName);
                if (findedGroups.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Groups has been finded \nGroup of Infos:");
                    Console.WriteLine(string.Join("\n", findedGroups));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given name");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please fill Name area");
                goto GroupNameInput;
            }
        }
        public void WriteToJson()
        {
            using FileStream fileStream = new(_path, FileMode.Create);
            using StreamWriter writer = new(fileStream);
            var datas = _groupService.GetAllGroups();
            string json = JsonSerializer.Serialize(datas);
            writer.Write(json);
            Helper.Print(ConsoleColor.Green, "All Group of Data Writed to DataBase");
        }
        public void GroupMenu()
        {
            while (true)
            {
            GroupMenu:
                Helper.Print(ConsoleColor.Yellow, "=== GROUP MENU ===");
                Helper.Print(ConsoleColor.Yellow, "1 - Create, \n2 - Update, \n3 - Delete, \n4 - GetById, " +
                "\n5 - Get By Teacher, \n6 - Get By Room, \n7 - Get All, \n8 - Search by Group Name, \n9 - Write All Group Datas to DataBase," +
                "\n0 - Back to Main Menu");

                Helper.Print(ConsoleColor.Blue, "Enter Your Choice");

                string selectedOption = Console.ReadLine();
                int selectedOptionNum;
                bool isSelectedOption = int.TryParse(selectedOption, out selectedOptionNum);

                if (isSelectedOption)
                {
                    if (selectedOptionNum == 0) break;

                    switch (selectedOptionNum)
                    {
                        case 1: CreateGroup(); break;
                        case 2: UptadeGroup(); break;
                        case 3: DeleteGroup(); break;
                        case 4: GetGroupById(); break;
                        case 5: GetGroupsByTeacher(); break;
                        case 6: GetGroupsByRoom(); break;
                        case 7: GetAllGroups(); break;
                        case 8: SearchForGroupsByName(); break;
                        case 9: WriteToJson(); break;
                        default:
                            Helper.Print(ConsoleColor.Red, "Please enter valid option value");
                            goto GroupMenu;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter valid option type");
                    goto GroupMenu;
                }
            }
        }
    }
}

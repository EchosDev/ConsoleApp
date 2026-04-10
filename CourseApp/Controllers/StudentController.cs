using CourseApp.Helpers;
using CourseAppCore.Entities;
using CourseAppService.Services.Implementations;
using CourseAppService.Services.Interfaces;
using System.Text.RegularExpressions;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        private static StudentService _studentService = new();

        public void CreateStudent()
        {
        StudentInput:
            Helper.Print(ConsoleColor.Blue, "Enter Student Name:");
            string studentName = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Student Surname:");
            string studentSurname = Console.ReadLine();

            Helper.Print(ConsoleColor.Blue, "Enter Student Age (17+):");
            string studentAgeStr = Console.ReadLine();

            int studentAge;

            bool isStudentAge = int.TryParse(studentAgeStr, out studentAge);

            Helper.Print(ConsoleColor.Blue, "Enter Student GroupID:");
            string studentGroupIdStr = Console.ReadLine();

            int studentGroupId;

            bool isStudentGroupId = int.TryParse(studentGroupIdStr, out studentGroupId);

            if (isStudentGroupId && isStudentAge && !string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(studentSurname))
            {
                if (studentAge >= 17)
                {
                    Student student = new() { Name = studentName, Surname = studentSurname, Age = studentAge };
                    var createdStudent = _studentService.CreateStudent(studentGroupId, student);

                    if (createdStudent is not null) Helper.Print(ConsoleColor.Green, $"Student has been created \nStudent Info: {createdStudent}");
                }
                else Helper.Print(ConsoleColor.Red, $"Age must be greater than 17. You entered: {studentAge}");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid values");
                goto StudentInput;
            }
        }
        public void UpdateStudent()
        {
        IdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Student Id:");
            string studentIdStr = Console.ReadLine();
            int studentId;
            bool isStudentId = int.TryParse(studentIdStr, out studentId);

            if (isStudentId)
            {
                bool isStudentIdNull = _studentService.GetStudentById(studentId) is not null ? true : false;
                if (isStudentIdNull)
                {
                    Helper.Print(ConsoleColor.Yellow, "If you don't want to change any value, leave it empty");
                    Helper.Print(ConsoleColor.Blue, "Enter New Student Name:");
                    string studentName = Console.ReadLine();

                    Helper.Print(ConsoleColor.Blue, "Enter New Student Surname:");
                    string studentSurname = Console.ReadLine();
                AgeInput:
                    Helper.Print(ConsoleColor.Blue, "Enter New Student Age:");
                    string studentAgeStr = Console.ReadLine();

                    int studentAge;
                    bool isStudentAge = int.TryParse(studentAgeStr, out studentAge);

                    Helper.Print(ConsoleColor.Blue, "Enter New Student GroupID:");
                    string studentGroupIdStr = Console.ReadLine();

                    int studentGroupId;

                    bool isStudentGroupId = int.TryParse(studentGroupIdStr, out studentGroupId);

                    if (isStudentAge && isStudentGroupId)
                    {
                        var updatedStudent = _studentService.UpdateStudent(studentId, studentName, studentSurname, studentAge, studentGroupId);
                        Helper.Print(ConsoleColor.Green, $"Student has been updated \nStudent Info: {updatedStudent}");
                    }
                    else
                    {
                        Helper.Print(ConsoleColor.Red, "Please enter valid Age Or GroupID types");
                        goto AgeInput;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter existing student id");
                    goto IdInput;
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
                goto IdInput;
            }
        }
        public void DeleteStudent()
        {
        StudentIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Student ID:");
            string studentIdStr = Console.ReadLine();
            int studentId;
            bool isStudentId = int.TryParse(studentIdStr, out studentId);

            if (isStudentId)
            {
                bool isSuccesfullyDeleted = _studentService.DeleteStudent(studentId);
                if (isSuccesfullyDeleted) Helper.Print(ConsoleColor.Green, "Student has been deleted succesfully");
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid id type");
                goto StudentIdInput;
            }
        }
        public void GetStudentById()
        {
        StudentIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter Student ID:");
            string studentIdStr = Console.ReadLine();
            int studentId;
            bool isStudentId = int.TryParse(studentIdStr, out studentId);

            if (isStudentId)
            {
                var findedStudent = _studentService.GetStudentById(studentId);
                if (findedStudent is not null)
                {
                    Helper.Print(ConsoleColor.Green, $"Student has been finded \nStudent Info: {findedStudent}");
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given ID");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid ID type");
                goto StudentIdInput;
            }
        }
        public void GetStudentsByAge()
        {
        StudentAgeInput:
            Helper.Print(ConsoleColor.Blue, "Enter Student Age: ");

            string studentAgeStr = Console.ReadLine();

            int studentAge;

            bool isStudentAge = int.TryParse(studentAgeStr, out studentAge);

            if (isStudentAge)
            {
                var findedStudents = _studentService.GetAllStudentsByAge(studentAge);
                if (findedStudents.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Students has been finded \nStudent`s Infos:");
                    Console.WriteLine(string.Join("\n", findedStudents));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given age");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid Age type");
                goto StudentAgeInput;
            }
        }
        public void GetStudentsByGroupId()
        {
        StudentGroupIdInput:
            Helper.Print(ConsoleColor.Blue, "Enter GroupID for students: ");

            string studentGroupIdStr = Console.ReadLine();

            int groupId;

            bool isGroupId = int.TryParse(studentGroupIdStr, out groupId);

            if (isGroupId)
            {
                var findedStudents = _studentService.GetAllStudentsByGroupId(groupId);
                if (findedStudents.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Students has been finded \nStudent`s Infos:");
                    Console.WriteLine(string.Join("\n", findedStudents));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given GroupID");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please enter valid GroupID type");
                goto StudentGroupIdInput;
            }
        }
        public void GetAllStudents()
        {
            var findedStudents = _studentService.GetAllStudents();

            if (findedStudents.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Students has been finded \nStudent`s Infos:");
                Console.WriteLine(string.Join("\n", findedStudents));
                Console.ResetColor();
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "No result found");
            }
        }
        public void SearchStudentsByNameOrSurname()
        {
        StudentInput:
            Helper.Print(ConsoleColor.Blue, "Enter Name or Surname For students");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                var findedStudents = _studentService.SearchStudentsByNameOrSurname(input);
                if (findedStudents.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Students has been finded \nStudent`s Infos:");
                    Console.WriteLine(string.Join("\n", findedStudents));
                    Console.ResetColor();
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "No result found for the given name or surname");
                }
            }
            else
            {
                Helper.Print(ConsoleColor.Red, "Please fill input area");
                goto StudentInput;
            }
        }
        public void StudentMenu()
        {
            while (true)
            {
            StudentMenu:
                Helper.Print(ConsoleColor.Yellow, "=== STUDENT MENU ===");
                Helper.Print(ConsoleColor.Yellow, "1 - Create, \n2 - Update, \n3 - Delete, \n4 - GetById, " +
                "\n5 - Get By Age, \n6 - Get By GroupID, \n7 - Get All, \n8 - Search Student By Name or Surname, \n9 - Back to Main Menu");

                Helper.Print(ConsoleColor.Blue, "Enter Your Choice");

                string selectedOption = Console.ReadLine();
                int selectedOptionNum;
                bool isSelectedOption = int.TryParse(selectedOption, out selectedOptionNum);

                if (isSelectedOption)
                {
                    if (selectedOptionNum == 9) break;

                    switch (selectedOptionNum)
                    {
                        case 1: CreateStudent(); break;
                        case 2: UpdateStudent(); break;
                        case 3: DeleteStudent(); break;
                        case 4: GetStudentById(); break;
                        case 5: GetStudentsByAge(); break;
                        case 6: GetStudentsByGroupId(); break;
                        case 7: GetAllStudents(); break;
                        case 8: SearchStudentsByNameOrSurname(); break;
                        default:
                            Helper.Print(ConsoleColor.Red, "Please enter valid option value");
                            goto StudentMenu;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Please enter valid option type");
                    goto StudentMenu;
                }
            }
        }
    }
}

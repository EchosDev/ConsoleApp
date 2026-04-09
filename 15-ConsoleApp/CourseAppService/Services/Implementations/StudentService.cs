using CourseAppCore.Entities;
using CourseAppService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppService.Services.Implementations
{
    public class StudentService : IStudentService
    {
        public Student CreateStudent(Student group)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, string name, string surname, int age, int groupId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudentsByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchStudentBySurname(string surname)
        {
            throw new NotImplementedException();
        }


    }
}

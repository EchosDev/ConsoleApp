using CourseAppCore.Entities;
using CourseAppRepository.Exceptions;
using CourseAppRepository.Repositories.Implementations;
using CourseAppService.Services.Interfaces;

namespace CourseAppService.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private static int _studentId = 0;
        private static StudentRepository _studentRepository = new();
        private static GroupService _groupService = new();

        public Student CreateStudent(int groupId, Student student)
        {
            _studentId++;
            student.Id = _studentId;

            var group = _groupService.GetGroupById(groupId);
            student.Group = group;

            _studentRepository.Create(student);

            if (group is not null) return student;
            return null;
        }
        public Student UpdateStudent(int id, string name, string surname, int? age, int? groupId)
        {
            var existStudent = GetStudentById(id);
            if (!string.IsNullOrWhiteSpace(name)) existStudent.Name = name;
            if (!string.IsNullOrWhiteSpace(surname)) existStudent.Surname = surname;
            if (age.HasValue) existStudent.Age = age.Value;
            if (groupId.HasValue) existStudent.Group = _groupService.GetGroupById(groupId.Value);

            _studentRepository.Update(existStudent);
            return existStudent;
        }
        public bool DeleteStudent(int id)
        {
            var existStudent = GetStudentById(id);
            _studentRepository.Delete(existStudent);
            if (existStudent is null) return false;

            return true;
        }
        public Student GetStudentById(int id)
        {
            return _studentRepository.Get(i => i.Id == id);
        }
        public List<Student> GetAllStudentsByAge(int age)
        {
            return _studentRepository.GetAll(s => s.Age == age);
        }
        public List<Student> GetAllStudentsByGroupId(int groupId)
        {
            var group = _groupService.GetGroupById(groupId);

            return _studentRepository.GetAll(s => s.Group.Id == groupId);
        }
        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }
        public List<Student> SearchStudentsByNameOrSurname(string input)
        {
            return _studentRepository.GetAll(s => s.Name.ToLower().Contains(input.ToLower().Trim()) || s.Surname.ToLower().Contains(input.ToLower().Trim()));
        }
    }
}

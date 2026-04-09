using CourseAppCore.Entities;

namespace CourseAppService.Services.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(int groupId,Student student);
        Student UpdateStudent(int id, string name, string surname, int? age, int? groupId);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetAllStudentsByAge(int age);
        List<Student> GetAllStudentsByGroupId(int id);
        List<Student> GetAllStudents();
        List<Student> SearchStudentsByNameOrSurname(string input);
    }
}
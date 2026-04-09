using CourseAppCore.Entities;
using CourseAppRepository.Data;
using CourseAppRepository.Exceptions;
using CourseAppRepository.Repositories.Interfaces;

namespace CourseAppRepository.Repositories.Implementations
{
    public class StudentRepository : IRepositrory<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                if (AppDbContext<Student>.datas.Find(s => s.Name.ToLower().Trim() == data.Name.ToLower().Trim() && s.Surname.ToLower().Trim() == data.Surname.ToLower().Trim()) != null) throw new AlreadyExistException("This Student already exist");
                if (data.Group is null) throw new NotFoundException("Student`s group not found");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }
        public void Delete(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");

                AppDbContext<Student>.datas.Remove(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public void Update(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");

                int index = AppDbContext<Student>.datas.FindIndex(s => s.Id == data.Id);

                if (index == -1) throw new NotFoundException("Group to update not found");

                AppDbContext<Student>.datas[index] = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }
    }
}

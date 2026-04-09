using CourseAppCore.Entities;
using CourseAppRepository.Data;
using CourseAppRepository.Exceptions;
using CourseAppRepository.Repositories.Interfaces;

namespace CourseAppRepository.Repositories.Implementations
{
    public class GroupRepository : IRepositrory<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }
        public void Delete(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");

                AppDbContext<CourseGroup>.datas.Remove(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }
        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.Find(predicate) : null;
        }
        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate = null)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : AppDbContext<CourseGroup>.datas;
        }
        public void Update(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");

                int index = AppDbContext<CourseGroup>.datas.FindIndex(g => g.Id == data.Id);

                if (index == -1) throw new NotFoundException("Group to update not found");

                AppDbContext<CourseGroup>.datas[index] = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has been detected!Error message: {ex.Message}");
            }
        }
    }
}

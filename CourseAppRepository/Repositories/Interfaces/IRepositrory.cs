using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppRepository.Repositories.Interfaces
{
    public interface IRepositrory<T>
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}

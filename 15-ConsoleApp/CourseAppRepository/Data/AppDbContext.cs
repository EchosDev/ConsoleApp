using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppRepository.Data
{
    public static class AppDbContext<T>
    {
        public static List<T> datas;

        static AppDbContext()
        {
            datas = new List<T>();
        }
    }
}

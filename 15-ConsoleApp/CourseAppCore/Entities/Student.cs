using CourseAppCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppCore.Entities
{
    public  class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public CourseGroup Group { get; set; }
    }
}

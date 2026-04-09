using CourseAppCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppCore.Entities
{
    public  class Student : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
    }
}

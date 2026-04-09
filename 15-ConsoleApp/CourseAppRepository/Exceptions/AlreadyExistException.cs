using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppRepository.Exceptions
{
    public class AlreadyExistException :Exception
    {
        public AlreadyExistException(string message) : base(message) { }
    }
}

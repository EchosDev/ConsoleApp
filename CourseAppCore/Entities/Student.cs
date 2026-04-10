using CourseAppCore.Common;

namespace CourseAppCore.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public CourseGroup Group { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}, Group: {Group.Name}";
        }
    }
}

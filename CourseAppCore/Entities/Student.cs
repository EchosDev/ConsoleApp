using CourseAppCore.Common;
using CourseAppCore.Helpers;

namespace CourseAppCore.Entities
{
    public class Student : BaseEntity
    {
        private string _name;
        private string _surname;

        public string Name { get { return _name; } set { _name = value.ToCapitalize(); } }
        public string Surname { get { return _surname; } set { _surname = value.ToCapitalize(); } }
        public int Age { get; set; }
        public CourseGroup Group { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}, Group: {Group.Name}";
        }
    }
}

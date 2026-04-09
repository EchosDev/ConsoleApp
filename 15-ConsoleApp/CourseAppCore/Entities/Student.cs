using CourseAppCore.Common;

namespace CourseAppCore.Entities
{
    public class Student : BaseEntity
    {
        private int _age;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 17) _age = value;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Age must be greater than 17. You entered: {value}");
                    Console.ResetColor();
                }
            }
        }
        public CourseGroup Group { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}, Group: {Group.Name}";
        }
    }
}

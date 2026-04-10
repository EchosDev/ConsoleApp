using CourseAppCore.Common;
using CourseAppCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppCore.Entities
{
    public class CourseGroup : BaseEntity
    {
        private string _name;
        private string _teacher;
        public string Name { get { return _name; } set { _name = value.ToCapitalize(); } }
        public string Teacher { get { return _teacher; } set { _teacher = value.ToCapitalize(); } }
        public string Room { get; set; }
        public override string ToString()
        {
            return $"GroupID: {Id}, Group Name: {Name}, Teacher Name: {Teacher}, Room: {Room}";
        }
    }
}

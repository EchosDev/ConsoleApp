using CourseAppCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseAppCore.Entities
{
    public class CourseGroup :BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public override string ToString()
        {
            return $"GroupID: {Id}, Group Name: {Name}, Teacher Name: {Teacher}, Room: {Room}";
        }
    }
}

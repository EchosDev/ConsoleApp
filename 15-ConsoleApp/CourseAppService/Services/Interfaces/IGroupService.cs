using CourseAppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CourseAppService.Services.Interfaces
{
    public interface IGroupService
    {
        CourseGroup CreateGroup(CourseGroup group);
        CourseGroup UpdateGroup(int id,string name,string teacher,string room);
        void DeleteGroup(int id);
        CourseGroup GetGroupById(int id);
        List<CourseGroup> GetAllGroupsByTeacher(string teacher);
        List<CourseGroup> GetAllGroupsByRoom(string room);
        List<CourseGroup> GetAllGroups();
        List<CourseGroup> SearchByName(string name);
    }
}

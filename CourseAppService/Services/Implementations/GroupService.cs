using CourseAppCore.Entities;
using CourseAppRepository.Repositories.Implementations;
using CourseAppService.Services.Interfaces;

namespace CourseAppService.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private static int _groupId = 0;
        private static GroupRepository _groupRepository = new();

        public CourseGroup CreateGroup(CourseGroup group)
        {
            _groupId++;
            group.Id = _groupId;

            _groupRepository.Create(group);

            return group;
        }
        public CourseGroup UpdateGroup(int id, string name, string teacher, string room)
        {
            var existGroup = GetGroupById(id);
            if (!string.IsNullOrWhiteSpace(name)) existGroup.Name = name;
            if (!string.IsNullOrWhiteSpace(teacher)) existGroup.Teacher = teacher;
            if (!string.IsNullOrWhiteSpace(room)) existGroup.Room = room;
            _groupRepository.Update(existGroup);
            return existGroup;
        }
        public bool DeleteGroup(int id)
        {
            var group = GetGroupById(id);
            _groupRepository.Delete(group);
            if (group is null) return false;
            return true;
        }
        public CourseGroup GetGroupById(int id)
        {
            return _groupRepository.Get(i => i.Id == id);
        }
        public List<CourseGroup> GetAllGroupsByTeacher(string teacher)
        { 
            return _groupRepository.GetAll(g => g.Teacher.ToLower().Trim() == teacher.ToLower().Trim());
        }
        public List<CourseGroup> GetAllGroupsByRoom(string room)
        {
            return _groupRepository.GetAll(g => g.Room.ToLower().Trim() == room.ToLower().Trim());

        }
        public List<CourseGroup> GetAllGroups()
        {
            return _groupRepository.GetAll();
        }
        public List<CourseGroup> SearchByName(string name)
        {
            return _groupRepository.GetAll(g => g.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}

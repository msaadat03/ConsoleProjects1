using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
       
        void CreateGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(int id);
        Group GetGroupById(int id);
        IList<Group> GetAllGroupsByTeacher(string teacher);
        IList<Group> GetAllGroupsByRoom(string room);
        IList<Group> GetAllGroups();
        IList<Group> SearchGroupByName(string search);

    }
}

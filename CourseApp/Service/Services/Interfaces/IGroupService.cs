using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group CreateGroup(Group group);
        Group UpdateGroup(int id, Group group);
        void DeleteGroup(int id);
        Group GetGroupById(int id);
        List<Group> GetAllGroupByTeacher(string teacher);
        List<Group> GetAllGroupByRoom(string room);
        List<Group> GetAllGroup();
        List<Group> SearchGroupByName(string search);





    }
}

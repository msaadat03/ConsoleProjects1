using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class GroupService 
    {
        private GroupRepository _groupRepository;
        private static int _count; 

        public GroupService()
        {
          
            _groupRepository = new GroupRepository();
        }

       

      

        public void CreateGroup(Group group)
        {
            if (group == null)
                throw new ArgumentNullException("group");

            group.Id = ++_count;
            _groupRepository.Create(group);
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetGroupById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
            _groupRepository.Update(group);
            return group;
            }


        public void DeleteGroup(int id)
        {
            Group group = _groupRepository.GetById(id);
            _groupRepository.Delete(group);
        }

        public List<Group> GetAllGroups()
        {
            return _groupRepository.GetAll();
        }

        public Group GetGroupById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        }

        public List<Group> GetAllGroupsByRoom(string room)
        {
            return _groupRepository.GetAll(m => m.Room.Trim().ToLower() == (room.Trim().ToLower()));

        }

        public List<Group> GetAllGroupsByTeacher(string teacher)
        {
            return _groupRepository.GetAll(m => m.Teacher.Trim().ToLower() == (teacher.Trim().ToLower()));
        }

        public List<Group> SearchGroupByName(string search)
        {
            return _groupRepository.GetAll(group => group.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

    }
}


       
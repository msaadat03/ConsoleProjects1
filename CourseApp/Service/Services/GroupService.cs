using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class GroupService : IGroupService
    {

        private GroupRepository _grouprepository;
        private int _count;
        public GroupService()
        {
            _grouprepository = new GroupRepository();
        }
        public Group CreateGroup(Group group)
        {
            group.Id = _count;
            _grouprepository.Create(group);
            _count++;
            return group;
        }


            public void DeleteGroup(int id)
            {
            Group group = GetGroupById(id);
            _grouprepository.Delete(group);
            }

            public List<Group> GetAllGroup()
            {
            return _grouprepository.GetAll();
            }

            public List<Group> GetAllGroupByRoom(string room)
            {
                throw new System.NotImplementedException();
            }

            public List<Group> GetAllGroupByTeacher(string teacher)
            {
                throw new System.NotImplementedException();
            }

            public Group GetGroupById(int id)
            {
            var group = _grouprepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
            }

            public List<Group> SearchGroupByName(string search)
            {
              return _grouprepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.Trim().ToLower()));
            }

        public Group UpdateGroup(int id, Group group)
            {
            Group dbGroup = GetGroupById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
            _grouprepository.Update(group);
            return dbGroup;
            }
    }
    }


       
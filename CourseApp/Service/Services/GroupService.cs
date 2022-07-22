using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
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
                throw new System.NotImplementedException();
            }

            public List<Group> GetAllGroup()
            {
                throw new System.NotImplementedException();
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
                throw new System.NotImplementedException();
            }

            public Group UpdateGroup(int id, Group group)
            {
                throw new System.NotImplementedException();
            }
        }
    }


       
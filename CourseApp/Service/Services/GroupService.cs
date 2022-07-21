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

        public Group Create(Group group)
        {
            group.Id = _count;
            _grouprepository.Create(group);
            _count++;
            return group;
        }


        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Group GetById(int id)
        {
            var group = _grouprepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        
    }

        public Group Update(int id, Group group)
        {
            throw new System.NotImplementedException();
        }
    }
}
       
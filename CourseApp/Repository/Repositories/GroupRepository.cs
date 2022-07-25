using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repositories
{
    public class GroupRepository 
    {

        public void Create(Group data)
        {

            if (data == null) throw new NotFoundException("Data not found.");
            AppDbContext<Group>.datas.Add(data);
        }

        public void Delete(Group data)
        {
            if (data == null) throw new NotFoundException("Data not found.");
            AppDbContext<Group>.datas.Remove(data);
        }

    
        public void Update(Group data)
        {
            Group group = Get(m => m.Id == data.Id);
            group.Name = data.Name;
            group.Teacher = data.Teacher;
            group.Room = data.Room;
        }


        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public Group GetById(int id)
        {
            return AppDbContext<Group>.datas.FirstOrDefault(group => group.Id == id);
        }

        public Group Get(Predicate<Group> predicate)
        {

            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }
    }
}


        
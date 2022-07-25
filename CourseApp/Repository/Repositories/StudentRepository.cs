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
    public class StudentRepository 
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data notfound");

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Update(Student data)
        {
            Student student = GetById(data.Id);

            if (student == null)
                throw new NotFoundException("Student not found.");

            if (!string.IsNullOrEmpty(data.Name) && student.Name != data.Name)
                student.Name = data.Name;
            
            if (!string.IsNullOrEmpty(data.Surname) && student.Surname != data.Surname)
                student.Surname = data.Surname;

            if (data.Age > 0 && student.Age != data.Age)
                student.Age = data.Age;


            if (data.Group != null && !student.Group.Equals(data.Group))
                student.Group = data.Group;
        }

       

        public void Delete(Student data)
        {
            if (data is null) throw new NotFoundException("Student not found.");
            AppDbContext<Student>.datas.Remove(data);
        }

   

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : null;
        }

       

        public Student GetById(int id)
        {
            return AppDbContext<Student>.datas.FirstOrDefault(student => student.Id == id);
        }


        public IList<Student> GetByAge(int age)
        {
            return GetAll(student => student.Age == age);
        }

      
        public IList<Student> GetByGroupId(int groupId)
        {
            return GetAll(student => student.Group != null && student.Group.Id == groupId);
        }


    }
}

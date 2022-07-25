using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class StudentService 
    {

        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;

        private static int _count; 

       
        public StudentService()
        {
            _groupRepository = new GroupRepository();
            _studentRepository = new StudentRepository();
        }


        public Student CreateStudent(Student student, int groupId)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            _count++;
            return student;
        }

      
        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("student");

            _studentRepository.Update(student);
        }

      
        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student == null)
                throw new Exception("Student not found.");

            _studentRepository.Delete(student);
        }

        
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

       
        public List<Student> GetStudentsByAge(int age)
        {
            return (List<Student>)_studentRepository.GetByAge(age);
        }

       
        public List<Student> GetStudentsByGroupId(int groupId)
        {
            return (List<Student>)_studentRepository.GetByGroupId(groupId);
        }

       
        public List<Student> SearchStudentByName(string search)
        {
            return _studentRepository.GetAll(group => group.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || group.Surname.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

    }
}

using Domain.Models;
using System.Collections.Generic;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(Student student);
        void UpdateStudent(Student student);
        Student GetStudentById(int id);
        void DeleteStudent(int id);
        IList<Student> GetStudentsByAge(int age);
        IList<Student> GetStudentsByGroupId(int groupId);
        IList<Student> SearchStudentByName(string search);

    }
}

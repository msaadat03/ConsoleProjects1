using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        private StudentService _studentService;
        private GroupService _groupService;

        public StudentController(
            GroupService groupService,
            StudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public void Create()
        {

            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group id: ");
        GroupID: string groupId = Console.ReadLine();
            int selectedGroupId;


            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            var data = _groupService.GetGroupById(selectedGroupId);

            if (data != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Yellow, "Enter student name: ");

                StudentName: string studentName = Console.ReadLine();

                    foreach (var item in studentName)
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (item.ToString() == i.ToString())
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Name incorrect! ");
                                goto StudentName;
                            }
                        }
                    }


                    Helper.WriteConsole(ConsoleColor.Yellow, "Enter student surname: ");

                StudentSurname: string studentSurname = Console.ReadLine();

                    foreach (var sur in studentSurname)
                    {
                        for (int i = 0; i <= 9; i++)
                        {
                            if (sur.ToString() == i.ToString())
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Surname incorrect.");
                                goto StudentSurname;
                            }
                        }
                    }


                    Helper.WriteConsole(ConsoleColor.Yellow, "Enter student age: ");

                StudentAge: string studentAge = Console.ReadLine();

                    int Age;

                    bool isAge = int.TryParse(studentAge, out Age);


                    if (isAge)
                    {
                        Student student = new Student
                        {
                            Name = studentName,
                            Surname = studentSurname,
                            Age = Age,

                        };

                        var result = _studentService.CreateStudent(student, selectedGroupId);

                        if (result != null)
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $"Group name : {result.Group.Name} , Student ID: {result.Id} Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Something went wrong! :");
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Something went wrong! :");
                        goto StudentAge;
                    }
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id: ");
                goto GroupID;
            }
    }
    


        public void Update()
        {
            Update:
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter student id: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                Student student = _studentService.GetStudentById(studentId);
                if (student != null)
                {
                    Student studentToUpdate = new Student();
                    studentToUpdate.Id = student.Id;

                    Helper.WriteConsole(ConsoleColor.Yellow, "Add student name: ");
                    studentToUpdate.Name = Console.ReadLine();

                    Helper.WriteConsole(ConsoleColor.Yellow, "Add student surname: ");
                    studentToUpdate.Surname = Console.ReadLine();
                    EnterAge:
                    Helper.WriteConsole(ConsoleColor.Yellow, "Add student age: ");
                    if (!int.TryParse(Console.ReadLine(), out int age))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Incorrect age.");
                        goto EnterAge;
                    }
                    studentToUpdate.Age = age;

                    EnterGroup:
                    Helper.WriteConsole(ConsoleColor.Yellow, "Add new group id:");
                    if (!int.TryParse(Console.ReadLine(), out int groupId))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Incorrect group id.");
                        goto EnterGroup;
                    }

                    Group group = _groupService.GetGroupById(groupId);
                    if (group == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Group not found.");
                        goto EnterGroup;
                    }

                    studentToUpdate.Group = group;

                    _studentService.UpdateStudent(studentToUpdate);
                    Helper.WriteConsole(ConsoleColor.Green, student.ToString());
                    Helper.WriteConsole(ConsoleColor.Green, "Student updated successfully.");
                }
                else
                    Helper.WriteConsole(ConsoleColor.Yellow, "Student not found.");

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct student id.");
                goto Update;
            }
        }


        public void GetById()
        {
            GetById:
            Helper.WriteConsole(ConsoleColor.Yellow, "Add student id :");
            if (int.TryParse(Console.ReadLine(), out int groupid))
            {
                Student student = _studentService.GetStudentById(groupid);
                if (student != null)
                    Helper.WriteConsole(ConsoleColor.Green, student.ToString());
                else
                    Helper.WriteConsole(ConsoleColor.Yellow, "Student not found.");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Enter correct student id.");
                goto GetById;
            }

        }

        public void Delete()
        {
            GetById:
            Helper.WriteConsole(ConsoleColor.Yellow, "Add student id :");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                Student student = _studentService.GetStudentById(studentId);
                if (student != null)
                {
                    _studentService.DeleteStudent(student.Id);
                    Helper.WriteConsole(ConsoleColor.Cyan, "The student has been deleted.");
                }
                else
                    Helper.WriteConsole(ConsoleColor.Yellow, "Student not found.");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct student id.");
                goto GetById;
            }
        }


        public void GetByAge()
        {
            EnterAge:
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter student age to search:");
            
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                
                Helper.WriteConsole(ConsoleColor.Red, "Incorrect age.");
                goto EnterAge;
            }

            var students = _studentService.GetStudentsByAge(age);

            if (students.Count == 0)
                Helper.WriteConsole(ConsoleColor.Green, "Students not found.");

            foreach (var student in students)
            {
                Helper.WriteConsole(ConsoleColor.Green, student.ToString());
            }
        }

        public void GetByGroupId()
        {
            EnterGroupId:
            Helper.WriteConsole(ConsoleColor.Yellow, "Add a group id to search for students:");

            if (!int.TryParse(Console.ReadLine(), out int groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Incorrect group id.");
                goto EnterGroupId;
            }

            Group group = _groupService.GetGroupById(groupId);
            if (group == null)
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found.");
                goto EnterGroupId;
            }

            var students = _studentService.GetStudentsByGroupId(groupId);
                
            if (students.Count == 0)
                Helper.WriteConsole(ConsoleColor.Green, "Students not found.");

            foreach (var student in students)
            {
                Helper.WriteConsole(ConsoleColor.Green, student.ToString());
            }
        }


        public void SearchByName()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add a string to search for a students by name or surname:");

            var students = _studentService.SearchStudentByName(Console.ReadLine());

            if (students.Count == 0)
                Helper.WriteConsole(ConsoleColor.Green, "Students not found.");

            foreach (var student in students)
            {
                Helper.WriteConsole(ConsoleColor.Green, student.ToString());
            }
        }

    }
}

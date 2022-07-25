using CourseApp.Controllers;
using Service.Helpers;
using Service.Services;
using System;

namespace CourseApp
{

    public class Program
    {
        private static GroupController _groupController;
        private static StudentController _studentController;

        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();
            _groupController = new GroupController(groupService);
            _studentController = new StudentController(groupService, new StudentService());

            GetMenues();
            Helper.WriteConsole(ConsoleColor.Yellow, "Select one option :");

            while(true)
            {
                SelectOption: 
                string selectoption = Console.ReadLine();
                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectoption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {

                        case (int)Menues.CreateGroup:
                            _groupController.Create();
                            break;

                        case (int)Menues.UpdateGroup:
                            _groupController.Update();
                            break;

                        case (int)Menues.DeleteGroup:
                            _groupController.Delete();
                            break;

                        case (int)Menues.GetGroupById:
                            _groupController.GetById();
                            break;

                        case (int)Menues.GetAllGroupByTeacher:
                            _groupController.GetByTeacher();
                            break;

                        case (int)Menues.GetAllGroupByRoom:
                            _groupController.GetByRoom();
                            break;

                        case (int)Menues.GetAllGroups:
                            _groupController.GetAll();
                            break;

                        case (int)Menues.SearchGroupsByName:
                            _groupController.SearchByName();
                            break;

                        case (int)Menues.CreateStudent:
                            _studentController.Create();
                            break;

                        case (int)Menues.UpdateStudent:
                            _studentController.Update();
                            break;

                        case (int)Menues.DeleteStudent:
                            _studentController.Delete();
                            break;

                        case (int)Menues.GetStudentById:
                            _studentController.GetById();
                            break;

                        case (int)Menues.GetStudentByAge:
                            _studentController.GetByAge();
                            break;

                        case (int)Menues.GetAllStudentsByGroupId:
                            _studentController.GetByGroupId();
                            break;

                        case (int)Menues.SearchStudentsByNameOrSurname:
                            _studentController.SearchByName();
                            break;


                        default:
                            Helper.WriteConsole(ConsoleColor.Yellow, "Select correct option number!");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select one option :");
                    goto SelectOption;
                }
            }

        }

        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Magenta, "1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group  by id," +
                " 5 - Get all groups  by teacher , 6 - Get all groups by room, 7 - Get all groups, 8 - Search groups by name, " +
                " 9 - Create Student,  10 - Update Student , 11 - Delete student, 12 -  Get student  by id, 13 - Get students by age, " +
                "14 - Get all students  by group id , 15 - Search method for students by name or surname");

        }
    }
}

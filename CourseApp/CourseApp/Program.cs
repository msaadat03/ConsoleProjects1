using CourseApp.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();
            GroupController groupController = new GroupController();
            Helper.WriteConsole(ConsoleColor.Yellow, "Select one option :");

            GetMenues();
       
            while (true)
        {
                SelectOption: string selectoption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectoption, out selectTrueOption);

                if (isSelectOption )
                {
                    switch (selectTrueOption)
                    {

                        case (int)Menues.CreateGroup:
                            groupController.Create();
                            break;


                        case (int)Menues.UpdateGroup:
                            groupController.Update();
                            break;


                        case (int)Menues.DeleteGroup:
                            groupController.Delete();
                            break;


                        case (int)Menues.GetGroupById:
                            groupController.GetById();
                            break;


                        case (int)Menues.GetAllGroupByTeacher:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.GetAllGroupByRoom:
                            Console.WriteLine(selectTrueOption);
                            break;



                        case (int)Menues.GetAllGroups:
                            groupController.GetAll();
                            break;



                        case (int)Menues.SearchGroupsByName:
                            groupController.SearchByName();
                            break;



                        case (int)Menues.CreateStudent:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.UpdateStudent:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.DeleteStudent:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.GetStudentById:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.GetStudentByAge:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.GetAllStudentsByGroupId:
                            Console.WriteLine(selectTrueOption);
                            break;


                        case (int)Menues.SearchStudentsByNameOrSurname:
                            Console.WriteLine(selectTrueOption);
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

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
            Helper.WriteConsole(ConsoleColor.Yellow, "Select one option :");
            Helper.WriteConsole(ConsoleColor.Magenta, "1 - Create group; 2 - Get group by id; 3 - Update group; 4 - Delete group; 5 - Get All Groups; 6 - Create Student; 7 - Get All Group By Teacher; 8 - Get All Group By Room; 9 - Get All Group; 10 - Search Group By Name");
       
            
            while (true)
        {
                SelectOption: string selectoption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectoption, out selectTrueOption);

                if (isSelectOption )
                {
                    switch (selectTrueOption)
                    {
                        case 1:

                            Helper.WriteConsole(ConsoleColor.Yellow, "Add group name :");
                            string GroupName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Yellow, "Add teacher name :");
                            string GroupTeacher = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Yellow, "Add room name :");
                            string GroupRoom = Console.ReadLine();

                            if (true)
                            {
                                Group group = new Group()
                                {
                                    Name = GroupName,
                                    Teacher = GroupTeacher,
                                    Room = GroupRoom
                                };

                                var result = groupService.CreateGroup(group);
                                Helper.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Group name: {result.Name}, Teacher: {result.Teacher}, Group Room: {result.Room}");

                            }


                            break;

                        case 2:
                            Helper.WriteConsole(ConsoleColor.Yellow, "Add group id :");
                            GroupId: string groupId = Console.ReadLine();
                            int id;
                            bool isGroupId = int.TryParse(groupId, out id);

                            if (isGroupId)
                            {
                                Group group = groupService.GetGroupById(id);
                                if(group != null)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {group.Id}, Group name: {group.Name}, Teacher: {group.Teacher}, Group Room: {group.Room}");

                                }
                                else
                                {

                                    Helper.WriteConsole(ConsoleColor.Yellow, "Group not found");
                                    goto GroupId;

                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                                goto GroupId;
                            }

                            break;
                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 5:
                            List<Group> groups = groupService.GetAllGroup();
                            foreach (var item in groups)
                            {
                                Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name: {item.Name}, Teacher: {item.Teacher}, Group Room: {item.Room}");
                            }
                            break;
                        case 6:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 7:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 8:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 9:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 10:
                            Helper.WriteConsole(ConsoleColor.Yellow, "Add group serach group by name :");
                            SearchGroup: string search = Console.ReadLine();

                            List<Group> resultgroup = groupService.SearchGroupByName(search);
                            if (resultgroup !=null)
                            {
                                foreach (var item in resultgroup)
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name: {item.Name}, Teacher: {item.Teacher}, Group Room: {item.Room}");
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                                goto SearchGroup;
                            }
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
    }
}

using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();
            Helper.WriteConsole(ConsoleColor.Yellow, "Select one option :");
            Helper.WriteConsole(ConsoleColor.Magenta, "1 - Create group; 2 - Get group by id; 3 - Update group; 4 - Delete group; 5 - Get All Groups; 6 - Create Student" );
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

                                var result = groupService.Create(group);
                                Helper.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Group name: {result.Name}, Teacher: {result.Teacher}, Group Room: {result.Room}");

                            }


                            break;
                        case 2:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 4:
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
    }
}

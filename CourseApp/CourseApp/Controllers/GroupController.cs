using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();
        private readonly bool GroupName;
        private readonly bool GroupTeacher;

        public void Create()
        {
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

        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add group id :");
        GroupId: string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                Group group = groupService.GetGroupById(id);
                if (group != null)
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

        }

        public void GetAll()
        {
            List<Group> groups = groupService.GetAllGroup();
            foreach (var item in groups)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name: {item.Name}, Teacher: {item.Teacher}, Group Room: {item.Room}");
            }
        }

        public void SearchByName()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add group serach group by name :");
        SearchGroup: string search = Console.ReadLine();

            List<Group> resultgroup = groupService.SearchGroupByName(search);
            if (resultgroup != null)
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
        }

        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add group id :");
        GroupId: string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                groupService.DeleteGroup(id);
                Helper.WriteConsole(ConsoleColor.Cyan, "The group has been deleted");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type :");
                goto GroupId;
            }

        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add group id :");
        GroupId: string updateGroupId = Console.ReadLine();

            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);


            if (isGroupId)
            {
                Helper.WriteConsole(ConsoleColor.Yellow, "Add group new name :");
            Name: string groupNewName = Console.ReadLine();
                if (GroupName)
                {
                    Group group = new Group
                    {
                        Name = groupNewName,
                    };
                }


                Helper.WriteConsole(ConsoleColor.Yellow, "Add group new teacher :");
                Teacher: string groupNewTeacher = Console.ReadLine();
                if (GroupTeacher)
                {
                    Group group = new Group
                    {
                        Name = groupNewName,
                        Teacher = groupNewTeacher,
                    };
                }

                Helper.WriteConsole(ConsoleColor.Yellow, "Add group new room :");
            Room: string groupNewRoom = Console.ReadLine();
                if (true)
                {
                    Group group = new Group()
                    {
                        Name = groupNewName,
                        Teacher = groupNewTeacher,
                        Room = groupNewRoom,
                    };

                    var resultGroup = groupService.UpdateGroup(groupId, group);

                    if (resultGroup == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again: ");
                        goto GroupId;

                    }
                }
            }
        }
    }
}

        
    

  

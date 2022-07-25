using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        private GroupService _groupService;
    

        public GroupController(GroupService groupService)
        {
            this._groupService = groupService;
        }

       
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group name: ");
            string groupName = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group teacher name: ");
        TeacherName: string groupTeacher = Console.ReadLine();
            foreach (var item in groupTeacher)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (item.ToString() == i.ToString())
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Teacher name is incorrect");
                        goto TeacherName;
                    }
                }
            }

            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group room name: ");
            RoomName: string groupRoom = Console.ReadLine();
            foreach (var item in groupRoom)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (item.ToString() == i.ToString())
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Room name is incorrect");
                        goto RoomName;
                    }
                }
            }

            Group group = new Group
            {
                Name = groupName,
                Teacher = groupTeacher,
                Room = groupRoom
            };

            _groupService.CreateGroup(group);
            Helper.WriteConsole(ConsoleColor.Green, group.ToString());

        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Add group's id : ");

        GroupId: string updateGroupId = Console.ReadLine();

            int groupId;

            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {

                Helper.WriteConsole(ConsoleColor.Yellow, "Enter group new name: ");
                string groupNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Yellow, "Enter group new teacher name: ");
            NewTeacherName: string groupTeacherNewName = Console.ReadLine();

                foreach (var item in groupTeacherNewName)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Teacher new name is incorrect");
                            goto NewTeacherName;
                        }
                    }
                }

                Helper.WriteConsole(ConsoleColor.Yellow, "Enter group new room name: ");
                string groupRoomNewName = Console.ReadLine();

                Group group = new Group()
                {
                    Name = groupNewName,
                    Teacher = groupTeacherNewName,
                    Room = groupRoomNewName
                };

                var resultGroup = _groupService.Update(groupId, group);

                if (resultGroup == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, try again: ");
                    goto GroupId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {resultGroup.Id}, Group name : {resultGroup.Name}, Group's teacher name : {resultGroup.Teacher}, Group's room name : {resultGroup.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Enter correct group id:");
                goto GroupId;
            }

        }


        public void Delete()
        {
            Delete:
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group id :");
            if (int.TryParse(Console.ReadLine(), out int groupid))
            {
                Group group = _groupService.GetGroupById(groupid);
                if (group != null)
                {
                    _groupService.DeleteGroup(group.Id);
                    Helper.WriteConsole(ConsoleColor.Cyan, "The group has been deleted.");
                }
                else
                    Helper.WriteConsole(ConsoleColor.Yellow, "Group not found.");

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id.");
                goto Delete;
            }

        }

        public void GetAll()
        {
            foreach (Group group in _groupService.GetAllGroups())
                Helper.WriteConsole(ConsoleColor.Green, group.ToString());
        }


        public void GetById()
        {
            GetById:
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter group id :");
            if (int.TryParse(Console.ReadLine(), out int groupid))
            {
                Group group = _groupService.GetGroupById(groupid);
                if (group != null)

                    Helper.WriteConsole(ConsoleColor.Green, group.ToString());

                else

                    Helper.WriteConsole(ConsoleColor.Yellow, "Group not found.");
            }

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Enter correct group id.");

                goto GetById;
            }

        }



        public void GetByRoom()
        {

            Helper.WriteConsole(ConsoleColor.Yellow, "Get group by room name : ");
        RoomName: string room = Console.ReadLine();

            List<Group> resultRoom = _groupService.GetAllGroupsByRoom(room);

            if (resultRoom.Count != 0)
            {
                foreach (var item in resultRoom)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Group name : {item.Name}, Group's teacher name : {item.Teacher}, Group's room name : {item.Room}");
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found : ");
                goto RoomName;
            }
        }



        public void GetByTeacher()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter teacher name to search for groups:");

            var groups = _groupService.GetAllGroupsByTeacher(Console.ReadLine());

            if (groups.Count == 0)
                Helper.WriteConsole(ConsoleColor.Green, "Groups not found.");

            foreach (var group in groups)
            {
                Helper.WriteConsole(ConsoleColor.Green, group.ToString());
            }
        }



        public void SearchByName()
        {
            Helper.WriteConsole(ConsoleColor.Yellow, "Enter a string to search for a group by name:");

            var groups = _groupService.SearchGroupByName(Console.ReadLine());

          
            foreach (var group in groups)
            {
                Helper.WriteConsole(ConsoleColor.Green, group.ToString());
            }
        }

    }
}






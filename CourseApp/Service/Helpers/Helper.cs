using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();

        }
    }

    public enum Menues
    {
        Exit = 0,
        CreateGroup = 1,
        UpdateGroup = 2,
        DeleteGroup = 3,
        GetGroupById = 4,
        GetAllGroupByTeacher = 5,
        GetAllGroupByRoom = 6,
        GetAllGroups = 7,
        SearchGroupsByName = 8,
        CreateStudent = 9,
        UpdateStudent = 10,
        DeleteStudent = 11,
        GetStudentById = 12, 
        GetStudentByAge = 13,
        GetAllStudentsByGroupId = 14,
        SearchStudentsByNameOrSurname = 15
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Tasks;

namespace CapStoneTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskList> tasklist = TaskList.InitListOfTasks();
            Console.WriteLine("Welcome to the task logging database!");
            TaskList.ListTasks(tasklist);
            TaskList.GetUserInfo(tasklist);
        }
    }
}

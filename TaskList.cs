using System;
using System.Collections.Generic;
using System.Linq;



namespace Tasks
{
    class TaskList
    {
        #region//variables
        private string name;
        private string deets;
        private int item;
        private string date;
        private bool completed;
        #endregion

        #region //objects
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }
        public int Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
        public string Deets
        {
            get 
            {
                return deets;
            }
            set 
            {
                deets = value;
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                completed = value;
            }
        }
        #endregion

        #region//constructor
        public TaskList()
        {
            name = "default";
            item = 0;
            deets = "default";
            date = "default";
            completed = false;

        }
        public TaskList(string _name, int _item, string _desc, string _date, bool _completed)
        {
            name = _name;
            item = _item;
            deets = _desc;
            date = _date;
            completed = _completed;
        }
        #endregion


        #region//M-E-T-H-O-D
        //init
        public static List<TaskList> InitListOfTasks()
        {
            List<TaskList> tasks = new List<TaskList> {
            new TaskList("default", 0, "default", "1/11/1111", false),
             new TaskList("Kenny", 1, "Bathrooms", "4/44/1411", false),
                new TaskList("Ted", 2, "Sweep", "2/22/2222", false),
                 new TaskList("Bill", 3, "Yard", "3/33/3333", false),
            };
            return tasks;
        }
        //input
        public static void ListTasks(List<TaskList> tasklist)
        {
            string completed = "";
            Console.WriteLine();
            string tabs = String.Format("{0,8} {1,10} {2,8} {3,13} {4,11}\n", "DueDate", "Status", "Name",
                    "Item Number", "Task Description");
            Console.WriteLine(tabs);
            foreach (TaskList namez in tasklist)
            {
                if (namez.Completed != true)
                {
                    completed = "incomplete";
                }
                else
                {
                    completed = "completed";
                }
                string chart = String.Format("{0,-11}{1,-13}{2,-12}{3,-8}{4,-17}\n",
                            namez.Date, completed, namez.Name, namez.Item, namez.Deets);
                if (namez.Item != 0)
                {
                    Console.WriteLine(chart);

                }
            }
            Console.WriteLine();
        }
        public static void GetUserInfo(List<TaskList> tasklist)
        {
            
            bool proceed = true;
            while (proceed == true)
            {
                
                Console.WriteLine("1.List Task 2.Add Task 3.Delete Task");
                Console.WriteLine("4.Mark Task Complete 5.Quit");
                string input = Console.ReadLine().ToLower();
                if (input == "list task" || input == "1")
                {
                   ListTasks(tasklist);
                }
                else if (input == "add task" || input == "2")
                {
                    AddTask(tasklist);
                }
                else if (input == "delete task" || input == "3")
                {
                    ListTasks(tasklist);
                    Console.WriteLine();
                    tasklist = TaskList.DeleteTask(tasklist);
                }
                else if (input == "mark task complete" || input == "4")
                {
                    ListTasks(tasklist);
                    Console.WriteLine();
                  
                        MarkTaskComplete(tasklist);
                   
                }
                else if (input == "quit" || input == "5")
                {
                    proceed = Quit();
                }
                else
                {
                    Console.WriteLine("User input does not match operations! Please try again. ");
                }
            }
        }
        public static List<TaskList> AddTask(List<TaskList>tasklist)
        {
            int x = 1;
               foreach(TaskList item in tasklist)
                {
                if (item.Item != 0) {
                    x = item.Item + 1;
                }
                }
               
                Console.WriteLine("Please enter task you wish to add ");
                string task = Console.ReadLine();
                Console.WriteLine("Please enter name you wish to add ");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter due date you wish to add ");
                string date = Console.ReadLine();
                tasklist.Add(new TaskList { Name = name, Item = x, Deets = task, Date = date, Completed = false });
                return tasklist;
            

        }
        public static List<TaskList> DeleteTask(List<TaskList>tasklist)
        {
            int y = 1;
            int x = 0;
            bool proceed = false;
            string task = "default";
            while (proceed == false)
            {
                Console.WriteLine("Please enter the number of the task you want deleted: ");
                task = Console.ReadLine();
                x = int.Parse(task);
                if (x >= tasklist.Count)
                {
                    Console.WriteLine("Invalid input. Please try again!");
                    MarkTaskComplete(tasklist);
                }

                foreach (TaskList tasky in tasklist)
                {
                    if (tasky.Item == (x))
                    {
                        Console.WriteLine($"You entered task #{x} {tasky.Deets}");
                    }
                }

                Console.WriteLine($"Are you sure? (y/n)");
                string valid = Console.ReadLine().ToLower();
                if (valid.Contains("y"))
                {
                    proceed = true;
                }
                else GetUserInfo(tasklist);
            }

            //Clears selected task item number to 0. This will allow for task to be contained in the list history but not listed on screen.
            foreach (TaskList tasky in tasklist)
            {
                if (tasky.Item == (x))
                {
                    tasky.Item = 0;
                }
            }
            //Reorders visable list
           foreach (TaskList tasky in tasklist)
            {
                if (tasky.Item != 0) {
                    tasky.Item = y++;
                }
            }


            Console.WriteLine($"Task #{x} was deleted!");
            Console.WriteLine();
            return tasklist;
        }
        public static List<TaskList> MarkTaskComplete(List<TaskList> tasklist)
        {
            
            int x = 0;
            bool proceed = false;
            string finished = "default";
            while (proceed == false)
            {
                Console.WriteLine("Please enter the number of the task completed: ");
                finished = Console.ReadLine();
                x = int.Parse(finished);
            if (x >= tasklist.Count)
            {
                Console.WriteLine("Invalid input. Please try again!");
                MarkTaskComplete(tasklist);
            }

            foreach (TaskList tasky in tasklist)
                {
                    if (tasky.Item == (x))
                    {
                        Console.WriteLine($"You entered task #{x} {tasky.Deets}");
                    }
                }   

                Console.WriteLine($"Are you sure? (y/n)");
                string valid = Console.ReadLine().ToLower();
                if (valid.Contains("y"))
                {
                    proceed = true;
                }
                else GetUserInfo(tasklist);
            }

            foreach (TaskList tasky in tasklist)
            {
                if (tasky.Item == (x ))
                {
                    tasky.Completed = true;
                  

                }
            }

            Console.WriteLine($"Task {x} marked completed!");
            Console.WriteLine();
            return tasklist;
        }
      

        public static bool Quit()
        {
            Console.WriteLine("Thank you!");
            bool proceed = false;
            return proceed;
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Yelmanov Bohdan");
            user.AddTask("TO DO smth");

            user.ShowTasks();

            user.AddTask("TO DO smth 2.0");
            user.ShowTasks();

        }
    }

    // Originator

    class User
    {
        public string Fullname { get; set; }
        public List<string> Tasks = new List<string>();

        public User(string fullname)
        {
            Fullname = fullname;
        }

        public void AddTask(string name)
        {
            this.Tasks.Add(name);
        }

        public void ShowTasks()
        {
            Console.WriteLine("------------Tasks------------");
            foreach (string i in this.Tasks)
            {
                Console.WriteLine(i);
            }
        }
    }

}

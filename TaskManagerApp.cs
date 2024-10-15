using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TaskManager.Service;

namespace TaskManager
{
    public class TaskManagerApp
    {
        private readonly ITaskService _taskService;

        public TaskManagerApp(ITaskService taskService)
            { 
            _taskService = taskService;
            }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nTask Management System");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4' Mark As Completed");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        GetAllTasks();
                        break;

                    case "3":
                        RemoveTask();
                        break;

                    case"4":
                        MarkAsCompleted();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }

        private void AddTask()
        {
            Console.Write("Enter task name: ");
            var taskName = Console.ReadLine();
            _taskService.AddTask(taskName);
            Console.WriteLine("Task added!");

        }

        private void GetAllTasks()
        {
            Console.WriteLine("------Tasks Available------");
            var tasks = _taskService.GetAllTasks();
            if (tasks.Count() == 0)
            {
                Console.WriteLine("Ooops! you're out of tasks to manage");
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

        }

        private void RemoveTask()
        {
            Console.WriteLine("Enter ID of Task to remove");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == taskId);

                if (task != null)
                {
                    _taskService.RemoveTask(taskId);
                    Console.WriteLine("Task Removed!");
                }

                else
                {
                    Console.WriteLine("Task  not available");
                }
            }

            else
            {
                Console.WriteLine("Task ID MUST be an integer");
            }
            

        }

        private void MarkAsCompleted()
        {
            Console.WriteLine("Enter Task ID to mark as completed");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == taskId);

                if (task != null)
                {
                    _taskService.MarkAsCompleted(taskId);
                    Console.WriteLine("Task Marked as Completed!");
                }

                else
                {
                    Console.WriteLine("Task  not available");
                }
            }

            else
            {
                Console.WriteLine("Task ID MUST be an integer ");
            }

        }
    }


}

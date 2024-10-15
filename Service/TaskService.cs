using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager.Service
{
    public class TaskService : ITaskService
    {
        private readonly List<Tasks> _tasks = new List<Tasks>();
        private int _nextId = 1;

        public void AddTask(string name)
        {
            var task = new Tasks()
            {
                Id = _nextId++,
                Name = name
            };

            _tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return _tasks;
        }

        public void MarkAsCompleted(int Id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

    }
}

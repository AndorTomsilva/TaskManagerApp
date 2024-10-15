using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Service
{
    public interface ITaskService
    {
        void AddTask(string name);
        void RemoveTask(int Id);
        IEnumerable<Tasks> GetAllTasks();

        void MarkAsCompleted(int Id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager 
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public override string ToString()
        {
            return $"[ID: {Id}] {Name} - Completed: {IsCompleted}";
        }
    }
}
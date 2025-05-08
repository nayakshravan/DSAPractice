using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class TaskItem : IComparable<TaskItem>
    {
        public string Name { get; set; }
        public int Priority { get; set; } // Lower number = higher priority
        public int ExecutionTime { get; set; } // In milliseconds
        public DateTime Timestamp { get; } // For tie-breaking

        public TaskItem(string name, int priority, int executionTime)
        {
            Name = name;
            Priority = priority;
            ExecutionTime = executionTime;
            Timestamp = DateTime.Now;
        }

        public int CompareTo(TaskItem other)
        {
            int priorityCompare = Priority.CompareTo(other.Priority);
            if (priorityCompare == 0)
            {
                return Timestamp.CompareTo(other.Timestamp); // Tie-breaker
            }
            return priorityCompare;
        }
    }

    public class TaskScheduler
    {
        private SortedSet<TaskItem> _taskQueue;

        public TaskScheduler()
        {
            _taskQueue = new SortedSet<TaskItem>();
        }

        public void AddTask(TaskItem task)
        {
            _taskQueue.Add(task);
            Console.WriteLine($"Added: {task.Name} (Priority: {task.Priority}, Time: {task.ExecutionTime} ms)");
        }

        public void ExecuteAllTasks()
        {
            Console.WriteLine("**** Executing Tasks in Priority Order ****");

            foreach (var task in _taskQueue)
            {
                Console.WriteLine($"Executing: {task.Name}");
                System.Threading.Thread.Sleep(task.ExecutionTime); // Simulated execution
            }

            Console.WriteLine("*** All tasks completed. ***");
        }
    }
}

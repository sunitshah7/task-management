using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamSoft_Task_Tool.Model
{
    public interface ITaskService
    {
        TaskItem AddTask(TaskItem task);
        TaskItem EditTask(string id, TaskItem task);
        bool DeleteTask(string id);
        TaskItem GetTaskById(string id);
        TaskItem MoveTask(string id, string targetColumn);
    }

    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new();

        public TaskItem AddTask(TaskItem task)
        {
            task.Id = Guid.NewGuid().ToString();
            _tasks.Add(task);
            return task;
        }

        public TaskItem EditTask(string id, TaskItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            task.Name = updatedTask.Name;
            task.Description = updatedTask.Description;
            task.Deadline = updatedTask.Deadline;
            task.IsCompleted = updatedTask.IsCompleted;
            return task;
        }

        public bool DeleteTask(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            _tasks.Remove(task);
            return true;
        }

        public TaskItem GetTaskById(string id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskItem MoveTask(string taskId, string targetColumn)
        {
            var task = GetTaskById(taskId);
            if (task == null) return null;

            task.Column = targetColumn; // Update the column state
            return task;
        }
    }
}

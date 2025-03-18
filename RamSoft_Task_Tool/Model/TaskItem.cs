using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamSoft_Task_Tool.Model
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsFavorited { get; set; }
        public string Column { get; set; } // e.g., "ToDo", "In Progress", "Done"
        public string ImageUrl { get; set; } // URL to the uploaded image in Azure Blob Storage
    }
}

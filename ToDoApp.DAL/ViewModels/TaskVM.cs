using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DAL.ViewModels
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public bool IsArchived { get; set; }
        public TaskVM(ToDoApp.DAL.Models.Task task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Category = task.Category;
            Priority = task.Priority;
            DueDate = task.DueDate;
            Status = task.Status;
            IsArchived = task.IsArchived;
        }

    }

    
}

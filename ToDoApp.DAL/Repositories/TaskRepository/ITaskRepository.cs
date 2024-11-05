using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DAL.Models;
using Task = ToDoApp.DAL.Models.Task;
using ToDoApp.DAL.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Repositories.TaskRepository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTasksAsync(string userId, TaskFilterVM filter);
        Task<Task> GetTaskByIdAsync(string userId, int taskId);
        Task<IdentityResult> CreateTaskAsync(Task task);  // Повернення IdentityResult
        Task<IdentityResult> UpdateTaskAsync(Task task);  // Повернення IdentityResult
        Task<IdentityResult> DeleteTaskAsync(Task task);  // Повернення IdentityResult
        Task<IEnumerable<Task>> GetArchivedTasksAsync(string userId);
    }
}

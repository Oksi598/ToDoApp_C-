using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoApp.DAL.ViewModels;

namespace ToDoApp.BLL.Services.TaskService
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskVM>> GetTasksAsync(string userId, TaskFilterVM filter);
        Task<TaskVM> GetTaskByIdAsync(string userId, int taskId);
        Task<TaskVM> CreateTaskAsync(string userId, CreateTaskVM newTask);
        Task<bool> UpdateTaskAsync(string userId, int taskId, UpdateTaskVM updatedTask);
        Task<bool> DeleteTaskAsync(string userId, int taskId);
        Task<bool> ArchiveTaskAsync(string userId, int taskId);
        Task<IEnumerable<TaskVM>> GetArchivedTasksAsync(string userId);
    }

}

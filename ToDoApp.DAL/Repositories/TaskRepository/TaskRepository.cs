using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.Models;
using ToDoApp.DAL.ViewModels;
using Microsoft.AspNetCore.Identity;

using Task = ToDoApp.DAL.Models.Task;

namespace ToDoApp.DAL.Repositories.TaskRepository
{

    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetTasksAsync(string userId, TaskFilterVM filter)
        {
            var query = _context.Tasks.Where(t => t.UserId == userId && !t.IsArchived);

            if (!string.IsNullOrEmpty(filter.Category))
                query = query.Where(t => t.Category == filter.Category);

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status.Value);

            return await query.ToListAsync();
        }

        public async Task<Task> GetTaskByIdAsync(string userId, int taskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
        }

        public async Task<IdentityResult> CreateTaskAsync(Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;  
            }
            catch (Exception)
            {
                return IdentityResult.Failed();  
            }
        }

        public async Task<IdentityResult> UpdateTaskAsync(Task task)
        {
            try
            {
                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception)
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<IdentityResult> DeleteTaskAsync(Task task)
        {
            try
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception)
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<IEnumerable<Task>> GetArchivedTasksAsync(string userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && t.IsArchived)
                .ToListAsync();
        }
    }

}


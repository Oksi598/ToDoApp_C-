using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL.Data;
using ToDoApp.DAL.ViewModels;


namespace ToDoApp.BLL.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskVM>> GetTasksAsync(string userId, TaskFilterVM filter)
        {
            var query = _context.Tasks.Where(t => t.UserId == userId && !t.IsArchived);

            if (!string.IsNullOrEmpty(filter.Category))
                query = query.Where(t => t.Category == filter.Category);

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status.Value);

            var tasks = await query.ToListAsync();
            return tasks.Select(t => new TaskVM(t));
        }

        public async Task<TaskVM> GetTaskByIdAsync(string userId, int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
            return task == null ? null : new TaskVM(task);
        }

        public async Task<TaskVM> CreateTaskAsync(string userId, CreateTaskVM newTask)
        {
            var task = new DAL.Models.Task
            {
                Title = newTask.Title,
                Description = newTask.Description,
                Category = newTask.Category,
                Priority = newTask.Priority,
                DueDate = newTask.DueDate,
                Status = newTask.Status,
                UserId = userId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return new TaskVM(task);
        }

        public async Task<bool> UpdateTaskAsync(string userId, int taskId, UpdateTaskVM updatedTask)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
            if (task == null) return false;

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Category = updatedTask.Category;
            task.Priority = updatedTask.Priority;
            task.DueDate = updatedTask.DueDate;
            task.Status = updatedTask.Status;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(string userId, int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ArchiveTaskAsync(string userId, int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
            if (task == null) return false;

            task.IsArchived = true;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskVM>> GetArchivedTasksAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.IsArchived)
                .ToListAsync();

            return tasks.Select(t => new TaskVM(t));
        }
    }

}

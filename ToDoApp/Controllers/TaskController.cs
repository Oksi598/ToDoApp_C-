using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.BLL.Services.TaskService;
using ToDoApp.BLL.Validators;
using ToDoApp.DAL.ViewModels;

namespace ToDoApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : BaseController
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskVM>>> GetTasks([FromQuery] TaskFilterVM filter)
        {
            var userId = User.Identity.Name;
            var tasks = await _taskService.GetTasksAsync(userId, filter);
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskVM>> GetTaskById(int taskId)
        {
            var userId = User.Identity.Name;
            var task = await _taskService.GetTaskByIdAsync(userId, taskId);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskVM>> CreateTask([FromBody] CreateTaskVM newTask)
        {
            var userId = User.Identity.Name;
            var createdTask = await _taskService.CreateTaskAsync(userId, newTask);
            return CreatedAtAction(nameof(GetTaskById), new { taskId = createdTask.Id }, createdTask);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] UpdateTaskVM updatedTask)
        {
            var userId = User.Identity.Name;
            var result = await _taskService.UpdateTaskAsync(userId, taskId, updatedTask);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var userId = User.Identity.Name;
            var result = await _taskService.DeleteTaskAsync(userId, taskId);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPost("{taskId}/archive")]
        public async Task<IActionResult> ArchiveTask(int taskId)
        {
            var userId = User.Identity.Name;
            var result = await _taskService.ArchiveTaskAsync(userId, taskId);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("archived")]
        public async Task<ActionResult<IEnumerable<TaskVM>>> GetArchivedTasks()
        {
            var userId = User.Identity.Name;
            var archivedTasks = await _taskService.GetArchivedTasksAsync(userId);
            return Ok(archivedTasks);
        }
    }

}

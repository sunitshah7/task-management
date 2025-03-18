using Microsoft.AspNetCore.Mvc;
using RamSoft_Task_Tool.Model;

namespace RamSoft_Task_Tool.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Add a new task
        [HttpPost]
        public IActionResult AddTask([FromBody] TaskItem task)
        {
            var addedTask = _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = addedTask.Id }, addedTask);
        }

        // Edit a task
        [HttpPut("{id}")]
        public IActionResult EditTask(string id, [FromBody] TaskItem task)
        {
            var updatedTask = _taskService.EditTask(id, task);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

        // Delete a task
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(string id)
        {
            var result = _taskService.DeleteTask(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // Get task by ID
        [HttpGet("{id}")]
        public IActionResult GetTaskById(string id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPut("{id}/move")]
        public IActionResult MoveTask(string id, [FromBody] string targetColumn)
        {
            var updatedTask = _taskService.MoveTask(id, targetColumn);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }
    }
}

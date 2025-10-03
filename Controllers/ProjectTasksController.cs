using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.APP.Interface;
using TMS.Core.DTOs;
using TMS.Core.Entities;

namespace TMS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTasksController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _projectTaskService.GetAllTasksAsync();
            var dtos = tasks.Select(t => new ProjectTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                TeamId = t.TeamId
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _projectTaskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();

            var dto = new ProjectTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                TeamId = task.TeamId
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectTaskDto dto)
        {
            var projectTask = new ProjectTask
            {
                Title = dto.Title,
                Description = dto.Description,
                TeamId = dto.TeamId
            };

            var created = await _projectTaskService.CreateTaskAsync(projectTask);

            return Ok(new ProjectTaskDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                IsCompleted = created.IsCompleted,
                TeamId = created.TeamId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProjectTaskDto dto)
        {
            var projectTask = await _projectTaskService.GetTaskByIdAsync(id);
            if (projectTask == null) return NotFound();

            projectTask.Title = dto.Title;
            projectTask.Description = dto.Description;
            projectTask.TeamId = dto.TeamId;

            await _projectTaskService.UpdateTaskAsync(projectTask);
            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> PatchComplete(int id, [FromBody] bool isCompleted)
        {
            await _projectTaskService.PatchIsCompletedAsync(id, isCompleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectTaskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}

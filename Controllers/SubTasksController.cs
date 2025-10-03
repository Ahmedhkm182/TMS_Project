using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.APP.Interface;
using TMS.Core.Entities;

namespace TMS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubTasksController : ControllerBase
    {
        private readonly ISubTaskService _subTaskService;

        public SubTasksController(ISubTaskService subTaskService)
        {
            _subTaskService = subTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subTasks = await _subTaskService.GetAllSubTasksAsync();
            return Ok(subTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subTask = await _subTaskService.GetSubTaskByIdAsync(id);
            if (subTask == null) return NotFound();
            return Ok(subTask);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubTask subTask)
        {
            var created = await _subTaskService.CreateSubTaskAsync(subTask);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubTask subTask)
        {
            if (id != subTask.Id) return BadRequest();
            await _subTaskService.UpdateSubTaskAsync(subTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subTaskService.DeleteSubTaskAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/isCompleted")]
        public async Task<IActionResult> PatchIsCompleted(int id, [FromBody] bool isCompleted)
        {
            await _subTaskService.PatchIsCompletedAsync(id, isCompleted);
            return NoContent();
        }
    }
}

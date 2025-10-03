using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.APP.Interface;

namespace TMS_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusService _statusService;
        public TaskStatusController(ITaskStatusService statusService) => _statusService = statusService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _statusService.GetAllStatusesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _statusService.GetStatusByIdAsync(id);
            if (s == null) return NotFound();
            return Ok(s);
        }
    }
}

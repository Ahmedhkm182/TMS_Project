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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            var dtos = teams.Select(t => new TeamDto
            {
                Id = t.Id,
                Name = t.Name
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null) return NotFound();

            var dto = new TeamDto
            {
                Id = team.Id,
                Name = team.Name
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto dto)
        {
            var team = new Team { Name = dto.Name };
            var created = await _teamService.CreateTeamAsync(team);

            return Ok(new TeamDto { Id = created.Id, Name = created.Name });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateTeamDto dto)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null) return NotFound();

            team.Name = dto.Name;
            await _teamService.UpdateTeamAsync(team);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}

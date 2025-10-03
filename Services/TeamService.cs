using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.APP.Interface;
using TMS.Core.Entities;
using TMS.Infa.Repository;

namespace TMS.APP.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _repository;

        public TeamService(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
            => await _repository.GetAllAsync();

        public async Task<Team?> GetTeamByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<Team> CreateTeamAsync(Team team)
        {
            await _repository.AddAsync(team);
            await _repository.SaveChangesAsync();
            return team;
        }

        public async Task UpdateTeamAsync(Team team)
        {
            await _repository.UpdateAsync(team);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
                await _repository.SaveChangesAsync();
            }
        }
    }
}

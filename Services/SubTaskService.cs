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
    public class SubTaskService : ISubTaskService
    {
        private readonly IRepository<SubTask> _subTaskRepository;

        public SubTaskService(IRepository<SubTask> subTaskRepository)
        {
            _subTaskRepository = subTaskRepository;
        }

        public async Task<IEnumerable<SubTask>> GetAllSubTasksAsync()
        {
            return await _subTaskRepository.GetAllAsync();
        }

        public async Task<SubTask?> GetSubTaskByIdAsync(int id)
        {
            return await _subTaskRepository.GetByIdAsync(id);
        }

        public async Task<SubTask> CreateSubTaskAsync(SubTask subTask)
        {
            await _subTaskRepository.AddAsync(subTask);
            await _subTaskRepository.SaveChangesAsync();
            return subTask;
        }

        public async Task UpdateSubTaskAsync(SubTask subTask)
        {
            await _subTaskRepository.UpdateAsync(subTask);
            await _subTaskRepository.SaveChangesAsync();
        }

        public async Task DeleteSubTaskAsync(int id)
        {
            var subTask = await _subTaskRepository.GetByIdAsync(id);
            if (subTask != null)
            {
                await _subTaskRepository.DeleteAsync(subTask);
                await _subTaskRepository.SaveChangesAsync();
            }
        }

        public async Task PatchIsCompletedAsync(int id, bool isCompleted)
        {
            var subTask = await _subTaskRepository.GetByIdAsync(id);
            if (subTask != null)
            {
                subTask.IsCompleted = isCompleted;
                await _subTaskRepository.UpdateAsync(subTask);
                await _subTaskRepository.SaveChangesAsync();
            }
        }
    }
}

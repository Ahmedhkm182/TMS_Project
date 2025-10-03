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
  
        public class ProjectTaskService : IProjectTaskService
        {
            private readonly IRepository<ProjectTask> _repository;

            public ProjectTaskService(IRepository<ProjectTask> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<ProjectTask>> GetAllTasksAsync()
                => await _repository.GetAllAsync();

            public async Task<ProjectTask?> GetTaskByIdAsync(int id)
                => await _repository.GetByIdAsync(id);

            public async Task<ProjectTask> CreateTaskAsync(ProjectTask task)
            {
                await _repository.AddAsync(task);
                await _repository.SaveChangesAsync();
                return task;
            }

            public async Task UpdateTaskAsync(ProjectTask task)
            {
                await _repository.UpdateAsync(task);
                await _repository.SaveChangesAsync();
            }

            public async Task DeleteTaskAsync(int id)
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity != null)
                {
                    await _repository.DeleteAsync(entity);
                    await _repository.SaveChangesAsync();
                }
            }

            public async Task PatchIsCompletedAsync(int id, bool isCompleted)
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity != null)
                {
                    entity.IsCompleted = isCompleted;
                    await _repository.UpdateAsync(entity);
                    await _repository.SaveChangesAsync();
                }
            }
        }
    }

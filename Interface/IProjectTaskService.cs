using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Entities;

namespace TMS.APP.Interface
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ProjectTask>> GetAllTasksAsync();
        Task<ProjectTask?> GetTaskByIdAsync(int id);
        Task<ProjectTask> CreateTaskAsync(ProjectTask task);
        Task UpdateTaskAsync(ProjectTask task);
        Task DeleteTaskAsync(int id);
        Task PatchIsCompletedAsync(int id, bool isCompleted);
    }
}

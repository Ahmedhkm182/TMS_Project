using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Entities;

namespace TMS.APP.Interface
{
    public interface ISubTaskService
    {
        Task<IEnumerable<SubTask>> GetAllSubTasksAsync();
        Task<SubTask?> GetSubTaskByIdAsync(int id);
        Task<SubTask> CreateSubTaskAsync(SubTask subTask);
        Task UpdateSubTaskAsync(SubTask subTask);
        Task DeleteSubTaskAsync(int id);
        Task PatchIsCompletedAsync(int id, bool isCompleted);
    }
}

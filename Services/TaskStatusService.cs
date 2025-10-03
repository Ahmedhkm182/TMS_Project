using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.APP.Interface;
using TMS.Infa.Repository;

namespace TMS.APP.Services
{
    public class TaskStatusService : ITaskStatusService
    {
        public Task<IEnumerable<TaskStatus>> GetAllStatusesAsync()
        {
            var values = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>();
            return Task.FromResult((IEnumerable<TaskStatus>)values);
        }

        public Task<TaskStatus?> GetStatusByIdAsync(int id)
        {
            if (Enum.IsDefined(typeof(TaskStatus), id))
                return Task.FromResult<TaskStatus?>((TaskStatus)id);

            return Task.FromResult<TaskStatus?>(null);
        }
    }
}

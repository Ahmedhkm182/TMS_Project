using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.APP.Interface
{
    public interface ITaskStatusService
    {
        Task<IEnumerable<TaskStatus>> GetAllStatusesAsync();
        Task<TaskStatus?> GetStatusByIdAsync(int id);
    }
}

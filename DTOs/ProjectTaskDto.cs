using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.DTOs
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public List<SubTaskDto>? SubTasks { get; set; }
        public int TeamId { get; set; }
    }

    public class CreateProjectTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
    }
}

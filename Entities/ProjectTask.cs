using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }

       
        public bool IsCompleted { get; set; }
    }
}

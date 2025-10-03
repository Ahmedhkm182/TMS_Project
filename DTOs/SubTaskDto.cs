using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.DTOs
{
    public class SubTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int TaskId { get; set; }
    }

    public class CreateSubTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public int TaskId { get; set; }
    }
}

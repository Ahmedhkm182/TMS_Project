using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserDto>? Members { get; set; }
    }

    public class CreateTeamDto
    {
        public string Name { get; set; } = string.Empty;
    }
}

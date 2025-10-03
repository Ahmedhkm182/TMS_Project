using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.DTOs;
using TMS.Core.Entities;

namespace TMS.APP.Interface
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto); 
        Task<string> LoginAsync(LoginDto dto);
    }
}

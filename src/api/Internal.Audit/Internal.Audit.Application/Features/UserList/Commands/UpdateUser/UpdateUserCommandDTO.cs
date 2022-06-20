using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser
{
    public class UpdateUserCommandDTO
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = null!;
        public bool IsEnabled { get; set; }
        public bool IsAccountLocked { get; set; }
        public bool IsAccountExpired { get; set; }
        public bool IsPasswordExpired { get; set; }
    }
}

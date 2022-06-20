using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Queries.GetUserList
{
    public record GetUserListResponseDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Entity { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public bool IsEnabled { get; set; }
        public bool IsAccountLocked { get; set; }
        public bool IsAccountExpired { get; set; }
        public bool IsPasswordExpired { get; set; }

    }
}

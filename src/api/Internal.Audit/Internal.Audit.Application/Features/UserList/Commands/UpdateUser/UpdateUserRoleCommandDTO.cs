using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser;
public class UpdateUserRoleCommandDTO
{
    public Guid RoleId { get; set; }
    public Guid UserId { get; set; }
}

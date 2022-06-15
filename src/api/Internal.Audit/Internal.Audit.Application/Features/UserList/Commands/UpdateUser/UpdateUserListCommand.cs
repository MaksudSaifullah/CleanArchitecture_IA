using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserList.Commands.UpdateUser;
public class UpdateUserListCommand: IRequest<UpdateUserListResponseDTO>
{
    public UpdateEmployeeCommandDTO UserEmployee { get; set; } = null!;
    public UpdateUserRoleCommandDTO UserRole { get; set; } = null!;
    public UpdateUserCountryCommandDTO UserCountry { get; set; } = null!;

    //public Guid Id { get; set; }
    //public string Email { get; set; } = null!;
    //public string Password { get; set; } = null!;
    //public string UserName { get; set; } = null!;
    //public bool IsEnabled { get; set; }
    //public bool IsAccountLocked { get; set; }
    //public bool IsAccountExpired { get; set; }
    //public bool IsPasswordExpired { get; set; }
}

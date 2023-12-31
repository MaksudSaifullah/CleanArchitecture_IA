﻿
using Internal.Audit.Application.Common.Security;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Commands.UpdateUser;

[Authorize(Roles = "ADMIN")]
public class UpdateUserCommand: IRequest<UpdateUserResponseDTO>
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Status { get; set; }
    public bool LoginStatus { get; set; }
    public DateTime? LastLoginTime { get; set; }
}

using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;

public class AddAccessPrivilegeCommand : IRequest<AddAccessPrivilegeResponseDTO>
{
	public AddPasswordPolicyCommandDTO PasswordPolicy { get; set; } = null!;
	public AddUserLockingPolicyCommandDTO UserLockingPolicy { get; set; } = null!;
	public AddSessionPolicyCommandDTO SessionPolicy { get; set; } = null!;
}
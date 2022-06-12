using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.AddAccessPrivilege;

public class AddAccessPrivilegeCommand : IRequest<AddAccessPrivilegeResponseDTO>
{
	public AddPasswordPolicyDTO PasswordPolicy { get; set; } = null!;
	public AddUserLockingPolicyDTO UserLockingPolicy { get; set; } = null!;
	public AddSessionPolicyDTO SessionPolicy { get; set; } = null!;
}
using MediatR;

namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
public class UpdateAccessPrivilegeCommand : IRequest<UpdateAccessPrivilegeResponseDTO>
{
	public UpdatePasswordPolicyCommandDTO PasswordPolicy { get; set; } = null!;
	public UpdateUserLockingPolicyCommandDTO UserLockingPolicy { get; set; } = null!;
	public UpdateSessionPolicyCommandDTO SessionPolicy { get; set; } = null!;
}
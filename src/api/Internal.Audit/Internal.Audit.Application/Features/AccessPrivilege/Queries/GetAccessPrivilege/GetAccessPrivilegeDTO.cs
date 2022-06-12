
namespace Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
public record GetAccessPrivilegeDTO
{
	public GetPasswordPolicyDTO PasswordPolicy { get; set; } = null!;
	public GetUserLockingPolicyDTO UserLockingPolicy { get; set; } = null!;
	public GetSessionPolicyDTO SessionPolicy { get; set; } = null!;
}
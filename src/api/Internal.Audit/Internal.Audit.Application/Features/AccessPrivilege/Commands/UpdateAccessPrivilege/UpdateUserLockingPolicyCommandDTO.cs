
namespace Internal.Audit.Application.Features.AccessPrivilege.Commands.UpdateAccessPrivilege;
public class UpdateUserLockingPolicyCommandDTO
{
	public Guid Id { get; set; }
	public bool IsLockedOnNoLoginActivity { get; set; }
	public int NoLoginActivityDays { get; set; }
	public bool LockedOnFailedLoginAttempts { get; set; }
	public int NumberOfFailedLoginAttempts { get; set; }
	public int FailedLoginAttemptsDuration { get; set; }
	public int FailedLoginLockedDuration { get; set; }
	public bool UnlockedOnByAdmin { get; set; }
	public int UnlockedOnByAdminDuration { get; set; }
	public DateTime EffectiveFrom { get; set; }
	public DateTime? EffectiveTo { get; set; }
}

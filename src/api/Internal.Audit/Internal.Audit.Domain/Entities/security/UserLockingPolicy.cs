using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("UserLockingPolicy", Schema = "Security")]
public class UserLockingPolicy : EntityBase
{
	[Required]
	public bool IsLockedOnNoLoginActivity { get; set; }
	public int NoLoginActivityDays {get; set;}
	[Required]
    public bool LockedOnFailedLoginAttempts { get; set; }
	public int NumberOfFailedLoginAttempts { get; set; }
	public int FailedLoginAttemptsDuration { get; set; }
    public int FailedLoginLockedDuration { get; set; }
	[Required]
    public bool UnlockedOnByAdmin { get; set; }
    public int UnlockedOnByAdminDuration { get; set; }
	[Required]
	public DateTime EffectiveFrom { get; set; }
	public DateTime? EffectiveTo { get; set; }
}
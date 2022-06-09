using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("PasswordPolicy", Schema = "Security")]
public class PasswordPolicy : EntityBase
{
	[Required]
	public int MinLength { get; set; }
	[Required]
	public int MaxLength { get; set; }
	[Required]
	public bool IsAlphabetMandatory { get; set; }
	public int? AlphabetLength { get; set; }
	[Required]
	public bool IsNumberMandatory { get; set; }
	public int? NumericLength { get; set; }
	[Required]
	public bool IsSpecialCharsMandatory { get; set; }
	public int? SpecialCharsLength { get; set; }
	[Required]
	public bool IsPasswordChangeForcedOnFirstLogin { get; set; }
	[Required]
	public bool IsPasswordResetForcedPeriodically { get; set; }
	public int? ForcePasswordResetDays { get; set; }
	public int? NotifyPasswordResetDays { get; set; }
	[Required]
	public DateTime EffectiveFrom { get; set; }
	public DateTime? EffectiveTo { get; set; }
}

namespace Internal.Audit.Application.Features.AccessPrivilege.Queries.GetAccessPrivilege;
public record GetPasswordPolicyDTO
{
	public Guid Id { get; set; }
	public int MinLength { get; set; }
	public int MaxLength { get; set; }
	public bool IsAlphabetMandatory { get; set; }
	public int? AlphabetLength { get; set; }
	public bool IsNumberMandatory { get; set; }
	public int? NumericLength { get; set; }
	public bool IsSpecialCharsMandatory { get; set; }
	public int? SpecialCharsLength { get; set; }
	public bool IsPasswordChangeForcedOnFirstLogin { get; set; }
	public bool IsPasswordResetForcedPeriodically { get; set; }
	public int? ForcePasswordResetDays { get; set; }
	public int? NotifyPasswordResetDays { get; set; }
}
using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("Issue", Schema = "BranchAudit")]
public class Issue : EntityBase
{
	[Required]
	[MaxLength(20)]
	//[Index("TitleIndex", IsUnique = true)]
	public string Code { get; set; } = null!;
	//[Required]
	//public Guid AuditCreationId { get; set; }
	[Required]
	public Guid AuditScheduleId { get; set; }
	[Required]
	public Guid BranchId { get; set; }
    [Required]
    public Guid ImpactTypeId { get; set; }
    [Required]
    public Guid LikelihoodTypeId { get; set; }
    [Required]
	public Guid RatingTypeId { get; set; }
	[Required]
	public Guid StatusTypeId { get; set; }
	[Required]
	[MaxLength(500)]
	public string IssueTitle { get; set; } = null!;
	[Required]	
	public string Policy { get; set; } = null!;
	[Required]	
	public DateTime TargetDate { get; set; }
	[Required]
	public string Details { get; set; } = null!;
	[Required]
	public string RootCause { get; set; } = null!;
	[Required]
	public string BusinessImpact { get; set; } = null!;
	[Required]
	public string PotentialRisk { get; set; } = null!;
	[Required]
	public string AuditorRecommendation { get; set; } = null!;	
	public string? Remarks { get; set; }


    [NotMapped]
    public string AuditCode { get; set; } = null!;
    [NotMapped]
    public string IssueOwners { get; set; } = null!;
    [NotMapped]
    public string ActionOwners { get; set; } = null!;
    [NotMapped]
    public string? RatingType { get; set; }
    [NotMapped]
    public string? StatusType { get; set; }
    [NotMapped]
    public string? LikelihoodType { get; set; }
    [NotMapped]
    public string? ImpactType { get; set; }
    [NotMapped]
    public string? Branch { get; set; }



	[ForeignKey("AuditScheduleId")]
	public virtual AuditSchedule AuditSchedule { get; set; } = null!;
	//[ForeignKey("BranchId")]
	//public virtual Branch Branch { get; set; } = null!;
	public virtual CommonValueAndType CommonValueImpactType { get; set; }
	public virtual CommonValueAndType CommonValueLikelihoodType { get; set; }
	public virtual CommonValueAndType CommonValueRatingType { get; set; }
	public virtual CommonValueAndType CommonValueStatusType { get; set; } = null!;
	public virtual ICollection<IssueOwner> IssueOwnerList { get; set; } = null!;
	public virtual ICollection<IssueBranch> IssueBranchList { get; set; } = null!;
	//public virtual ICollection<IssueActionPlan> ActionPlanList { get; set; } = null!;
}
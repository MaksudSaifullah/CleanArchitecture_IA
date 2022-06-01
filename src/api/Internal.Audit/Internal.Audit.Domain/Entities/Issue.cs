using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;
[Table("Issue", Schema = "")]
public class Issue : EntityBase
{
	[Required]
	[MaxLength(20)]
	//[Index("TitleIndex", IsUnique = true)]
	public string Code { get; set; } = null!;
	[Required]
	public Guid AuditId { get; set; }
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
	[MaxLength(100)]
	public string IssueTitle { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string Policy { get; set; } = null!;
	[Required]	
	public DateTime TargetDate { get; set; }
	[Required]
	[MaxLength(500)]
	public string Details { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string RootCause { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string BusinessImpact { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string PotentialRisk { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string AuditorRecommendation { get; set; } = null!;	
	[MaxLength(500)]
	public string? Remarks { get; set; }
	[Required]
	[DefaultValue("1")]
	public bool IsActive { get; set; }
	//TODO
	//[ForeignKey("AuditId")]
	//public virtual Audit Audit { get; set; } = null!;
	//[ForeignKey("AuditScheduleId")]
	//public virtual AuditSchedule AuditSchedule { get; set; } = null!;
	//[ForeignKey("BranchId")]
	//public virtual Branch Branch { get; set; } = null!;
	[ForeignKey("ImpactTypeId")]
	public virtual ImpactType ImpactType { get; set; } = null!;
	[ForeignKey("LikelihoodTypeId")]
	public virtual LikelihoodType LikelihoodType { get; set; } = null!;
	[ForeignKey("RatingTypeId")]
	public virtual RatingType RatingType { get; set; } = null!;
	[ForeignKey("StatusTypeId")]
	public virtual StatusType StatusType { get; set; } = null!;

}
using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.Config.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit;

    [Table("RiskAssessment", Schema = "ProcessAndControlAudit")]
    public class RiskAssessment : EntityBase
    {
	
	public Guid CountryId { get; set; }  

	 public Guid AuditTypeId { get; set; } 

	 public Guid KeyIssuesTypeId { get; set; } 

	 public Guid IssueStatusTypeId { get; set; }

	[Required]
	[MaxLength(50)]
	public string AssessmentCode { get; set; } = null!;

	[Required]
	public DateTime EffectiveFrom { get; set; }

	[Required]
	public DateTime EffectiveTo { get; set; } 
  
	 public bool IsExternalAuditIssue { get; set; }

	[MaxLength(50)]
	public string? IssueName { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsManagementConcern { get; set; }


	[MaxLength(50)]
	public string? ManagementConcern { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsRegulatoryStatutoryRequirement { get; set; }


	[MaxLength(50)]
	public string? MentionRequirement { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight10FirstTimeAudit1 { get; set; }


	[MaxLength(50)]
	public string? WeightedScore1 { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight10KeyIssues2 { get; set; }

	[MaxLength(50)]
	public string? WeightedScore2 { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight10IssueStatus3 { get; set; }

	[MaxLength(50)]
	public string? WeightedScore3 { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight20ExternalAuditIssue4 { get; set; }

	[MaxLength(50)]
	public string? WeightedScore4 { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight20ManagementConcern5 { get; set; }

	[MaxLength(50)]
	public string? WeightedScore5 { get; set; }

	[Required]
	[DefaultValue("0")]
	public bool IsWeight30RegulatoryStatutoryRequirement6 { get; set; }

	[MaxLength(50)]
	public string? WeightedScore6 { get; set; }

	[Required]
	[MaxLength(50)]
	public string SummationOfWeights { get; set; } = null!;

	[Required]
	[MaxLength(50)]
	public string RiskRating { get; set; } = null!;

	[Required]
	[MaxLength(50)]
	public string AuditFrequency { get; set; } = null!;


	[ForeignKey("CountryId")]
	public virtual Country Country { get; set; } = null!;

	[ForeignKey("AuditTypeId")]
	public virtual AuditType AuditType { get; set; } = null!;

	[ForeignKey("KeyIssuesTypeId")]
	public virtual KeyIssuesType KeyIssuesType { get; set; } = null!;

	[ForeignKey("IssueStatusTypeId")]
	public virtual IssueStatus IssueStatus { get; set; } = null!;

}

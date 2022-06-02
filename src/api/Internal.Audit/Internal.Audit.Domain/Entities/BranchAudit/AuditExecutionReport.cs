using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("AuditExecutionReport", Schema = "BranchAudit")]
public class AuditExecutionReport : EntityBase
{
    [Required]
    [MaxLength(20)]
    public string Code { get; set; } = null!;
    [Required]
    public Guid AuditId { get; set; }
    [Required]
    public Guid CountryId { get; set; }
    [Required]
    public Guid ReportIssuedBy { get; set; }
    public Guid? ReportReviewedBy { get; set; }
    public Guid? ReportApprovedBy { get; set; }
    public Guid? ReviewEvidenceId { get; set; }
    public Guid? ApprovalEvidenceId { get; set; }
    [Required]
    public DateTime ReportIssueDate { get; set; }
    [Required]
    [MaxLength(500)]
    public string Environment { get; set; } = null!;    
    [MaxLength(500)]
    public string? ScopeOfReview { get; set; }
    [MaxLength(500)]
    public string? Opinion { get; set; }
    public DateTime? ReportReviewDate { get; set; }
    public DateTime? ReportApproveDate { get; set; }    

    [Required]
    [DefaultValue("0")]
    public int DraftVersion { get; set; }
    [Required]
    [DefaultValue("0")]
    public bool IsFinal { get; set; }
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    //TODO: AUDIT
    //[ForeignKey("AuditId")]
    //public virtual Audit Audit { get; set; } = null!;
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
    [ForeignKey("ReportIssuedBy")]
    public virtual Employee ReportIssuer { get; set; } = null!;
    [ForeignKey("ReportReviewedBy")]
    public virtual Employee ReportReviewer { get; set; } = null!;
    [ForeignKey("ReportApprovedBy")]
    public virtual Employee ReportApprover { get; set; } = null!;
    //TODO: Document
    //[ForeignKey("ReviewEvidenceId")]
    //public virtual Document ReviewEvidence { get; set; }
    //[ForeignKey("ApprovalEvidenceId")]
    //public virtual Document ApprovalEvidence { get; set; }
}
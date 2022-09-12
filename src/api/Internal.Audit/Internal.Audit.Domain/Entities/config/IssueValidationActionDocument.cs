using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.BranchAudit;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Config;

[Table("IssueValidationActionDocument", Schema = "Config")]
public class IssueValidationActionDocument : EntityBase
{
    [Required]
    public Guid IssueValidationActionPlanId { get; set; }
    [Required]
    public Guid IssueValidationActionDocumentTypeId { get; set; }
    [Required]
    public Guid DocumentId { get; set; }
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    [ForeignKey("IssueValidationActionPlanId")]
    public virtual IssueValidationActionPlanDraft IssueValidationActionPlan { get; set; } = null!;
    [ForeignKey("IssueValidationActionDocumentTypeId")]
    public virtual IssueValidationActionDocumentType IssueValidationActionDocumentType { get; set; } = null!;
    //TODO
    //[ForeignKey("DocumentId")]
    //public virtual Document Document { get; set; } = null!;
}
using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("IssueBranch", Schema = "BranchAudit")]
public class IssueBranch : EntityBase
{
    [Required]
    public Guid IssueId { get; set; }
    [Required]
    public Guid BranchId { get; set; }
    [Required]

    [ForeignKey("IssueId")]
    public virtual Issue Issue { get; set; } = null!;

}


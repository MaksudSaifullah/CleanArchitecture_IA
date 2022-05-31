using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;
[Table("AuditExecutionReportIssue", Schema = "")]
public class AuditExecutionReportIssue : EntityBase
{
    [Required]
    public Guid AuditExecutionReportId { get; set; }
    [Required]
    public Guid IssueId { get; set; }


    [ForeignKey("AuditExecutionReportId")]
    public virtual AuditExecutionReport AuditExecutionReport { get; set; } = null!;
    [ForeignKey("IssueId")]
    public virtual Issue Issue { get; set; } = null!;
}

using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("ClosingMeetingSubjects", Schema = "BranchAudit")]
public class ClosingMeetingSubject : EntityBase
{
    public Guid UserId { get; set; }

    public Guid ClosingMeetingMinutesId { get; set; }

    [Required]
    [MaxLength(500)]
    public string? SubjectMatter { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
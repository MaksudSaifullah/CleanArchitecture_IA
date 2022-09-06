using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Config;

[Table("IssueOwner", Schema = "Config")]
public class IssueOwner : EntityBase
{
	[Required]
	public Guid IssueId { get; set; }
	[Required]
	public Guid OwnerId { get; set; }


	[ForeignKey("IssueId")]
	public virtual Issue Issue { get; set; } = null!;
	[ForeignKey("OwnerId")]
	public virtual Employee Employee { get; set; } = null!;
}

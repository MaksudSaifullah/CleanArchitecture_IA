using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;
[Table("IssueStatusHistory", Schema = "")]
public class IssueStatusHistory : EntityBase
{
	[Required]
	public Guid IssueId { get; set; }
	[Required]
	public Guid IssueStatusTypeId { get; set; }
	[Required]
	public Guid ModifiedById { get; set; }
	[Required]
	public DateTime ModificationDate { get; set; }
	[Required]
	[DefaultValue("1")]
	public bool IsActive { get; set; }


	[ForeignKey("IssueId")]
	public virtual Issue Issue { get; set; } = null!;
	[ForeignKey("IssueStatusTypeId")]
	public virtual StatusType StatusType { get; set; } = null!;
	[ForeignKey("ModifiedById")]
	public virtual Employee Employee { get; set; } = null!;

}
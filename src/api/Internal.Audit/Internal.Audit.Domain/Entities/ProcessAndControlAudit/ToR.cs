
using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit;

[Table("ToR", Schema = "ProcessAndControlAudit")]
//[Index(nameof(Code), IsUnique = true)]
public class ToR : EntityBase
{
	[Required]
	[MaxLength(20)]	
	public string Code { get; set; } = null!;
	[Required]
    public Guid AuditId { get; set; }
	[Required]
	public Guid AuditableFunctionId { get; set; }
	[Required]
	[MaxLength(500)]
	public string AuditObjection { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string ScopeNCoverage { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string OutOfScope { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string Methodology { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string ProcedureNGuidelineReference { get; set; } = null!;
	[Required]
	[MaxLength(500)]
	public string AuditResources { get; set; } = null!;
	[Required]
	[DefaultValue(0)]
	public bool IsMailSent { get; set; }
	[Required]
	[MaxLength(100)]
	public string MailTo { get; set; } = null!;
	[Required]
	[MaxLength(100)]
	public string MailCc { get; set; } = null!;
	[Required]
	[MaxLength(100)]
	public string MailBcc { get; set; } = null!;

	//TODO: Audit
	//[ForeignKey("AuditId")]
	//public virtual Audit Audit { get; set; } = null!;
	//[ForeignKey("AuditableFunctionId")]
	//public virtual AuditableFunction AuditableFunction { get; set; } = null!;
}
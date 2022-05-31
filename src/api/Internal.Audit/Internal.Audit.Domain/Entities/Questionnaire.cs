using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("Questionnaire", Schema = "")]
public class Questionnaire : EntityBase
{
	[Required]
	public Guid CountryId { get; set; }
	[Required]
	public Guid TopicHeadId { get; set; }
	[Required]
	[MaxLength(500)]
	public string Question { get; set; } = null!;
	[Required]
	public DateTime EffectiveFrom { get; set; }
	[Required]
	public DateTime EffectiveTo { get; set; }
	[Required]
	[DefaultValue("1")]
	public bool IsActive { get; set; }

	[ForeignKey("CountryId")]
	public virtual Country Country { get; set; } = null!;
	//TODO: TopicHead
	//[ForeignKey("TopicHeadId")]
	//public virtual TopicHead TopicHead { get; set; } = null!;
}
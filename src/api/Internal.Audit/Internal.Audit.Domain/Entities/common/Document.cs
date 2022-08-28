using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.common;

[Table("Document", Schema = "Common")]
public class Document: EntityBase
{
    [Required]
    public Guid DocumentSourceId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Path { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Format { get; set; } = null!;
    [NotMapped]

    [ForeignKey("DocumentSourceId")]
    public virtual DocumentSource DocumentSource { get; set; } = null!;
}

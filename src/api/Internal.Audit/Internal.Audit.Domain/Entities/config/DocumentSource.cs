using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.config;

[Table("Document", Schema = "config")]
public class DocumentSource : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }
}

using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Config;

[Table("ImpactType", Schema = "Config")]
public class ImpactType : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }
}

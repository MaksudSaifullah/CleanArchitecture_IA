using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("SubProcess", Schema = "")]
public class SubProcess : EntityBase
{
    [Required]
    public Guid ProcessId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [Required]
    public DateTime EffeciveFrom { get; set; }
    [Required]
    public DateTime EffeciveTo { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }

    //[ForeignKey("ProcessId")]
    //public virtual Process Process { get; set; } = null!;
}
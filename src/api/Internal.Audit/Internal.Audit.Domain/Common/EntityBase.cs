
using System.ComponentModel.DataAnnotations;

namespace Internal.Audit.Domain.Common;

public abstract class EntityBase
{
    [Key]
    public long Id { get; protected set; }
    [Required]
    [MaxLength(50)]
    public string CreatedBy { get; set; } = null!;
    [Required]
    public DateTime CreatedOn { get; set; }
    [MaxLength(50)]
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}

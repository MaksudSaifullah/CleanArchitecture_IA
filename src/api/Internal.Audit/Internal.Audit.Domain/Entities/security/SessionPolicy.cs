using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("SessionPolicy", Schema = "Security")]
public class SessionPolicy : EntityBase
{
    [Required]
    public bool IsEnabled { get; set; }
    [Required]
    public int Duration { get; set; }
    [Required]
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}
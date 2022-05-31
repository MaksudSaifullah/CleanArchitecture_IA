using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;
[Table("DETestQuestion", Schema = "")]
public class DETestQuestion : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Question { get; set; } = null!;
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }
}
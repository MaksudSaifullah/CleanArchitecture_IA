using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("DashBoardBase", Schema = "")]
public class DashBoardBase : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [DefaultValue(1)]
    public bool Status { get; set; }
}
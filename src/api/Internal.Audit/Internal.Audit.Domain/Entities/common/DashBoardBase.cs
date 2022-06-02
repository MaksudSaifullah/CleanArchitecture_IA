using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Common;

[Table("DashBoardBase", Schema = "Common")]
public class DashBoardBase : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [DefaultValue(1)]
    public bool Status { get; set; }
}
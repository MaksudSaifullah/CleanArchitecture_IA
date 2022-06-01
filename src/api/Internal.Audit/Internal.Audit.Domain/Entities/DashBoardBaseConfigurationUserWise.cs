using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("DashBoardBaseConfigurationUserWise", Schema = "")]
public class DashBoardBaseConfigurationUserWise : EntityBase
{
    [Required]
    public Guid DashBoardBaseId { get; set; }
    [Required]    
    public Guid UserId { get; set; }

    [ForeignKey("DashBoardBaseId")]
    public virtual DashBoardBase DashBoardBase { get; set; } = null!;
    [ForeignKey("UserId")]
    public virtual Employee User { get; set; } = null!;
}
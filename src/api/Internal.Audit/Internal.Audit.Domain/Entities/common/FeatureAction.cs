using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Common;

[Table("FeatureAction", Schema = "Common")]
public class FeatureAction : EntityBase
{
    [Required]
    public Guid ModuleId { get; set; }
    [Required]
    public Guid FeatureId { get; set; }

    [Required]
    public Guid ActionId { get; set; }

    [ForeignKey("ModuleId")]
    public virtual AuditModule Module { get; set; } = null!;

    [ForeignKey("FeatureId")]
    public virtual AuditFeature Feature { get; set; } = null!;

    [ForeignKey("ActionId")]
    public virtual AuditAction Action { get; set; } = null!;

}

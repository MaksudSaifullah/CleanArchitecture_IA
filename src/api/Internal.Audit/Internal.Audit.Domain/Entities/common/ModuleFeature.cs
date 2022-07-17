using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Common;

[Table("ModuleFeature", Schema = "Common")]
public class ModuleFeature : EntityBase
{
    [Required]
    public Guid ModuleId { get; set; }

    [Required]
    public Guid FeatureId { get; set; }


    [ForeignKey("ModuleId")]
    public virtual AuditModule Module { get; set; } = null!;

    [ForeignKey("FeatureId")]
    public virtual AuditFeature Feature { get; set; } = null!;
    [NotMapped]
    public virtual EfTotalCount TotalCount { get; set; }
    [NotMapped]
    public int RowSpan { get; set; }
}

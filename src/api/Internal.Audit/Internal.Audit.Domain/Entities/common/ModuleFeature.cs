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

[Table("ModuleFeature", Schema = "Common")]
public class ModuleFeature : EntityBase
{
    [Required]
    public Guid ModuleId { get; set; }

    [Required]
    public Guid FeatureId { get; set; }


    [ForeignKey("ModuleId")]
    public virtual Module Module { get; set; } = null!;

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; } = null!;
}

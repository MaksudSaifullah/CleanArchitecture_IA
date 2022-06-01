using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Security;

[Table("RoleFeature", Schema = "Security")]
public class RoleFeature : EntityBase
{
    [Required]
    public Guid FeatureId { get; set; }
    [Required]
    public Guid RoleId { get; set; }

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; } = null!;

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;

}


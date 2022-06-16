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


[Table("Action", Schema = "Common")]
public class AuditAction : EntityBase
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string DisplayName { get; set; } = null!;

    [Required]
    [DefaultValue("0")]
    public bool IsActive { get; set; }

    public virtual ICollection<FeatureAction> featureActions { get; set; } = null!;


}

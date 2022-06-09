using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.Security;

[Table("Role", Schema = "Security")]
public class Role : EntityBase
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Description { get; set; } = null!;

    [Required]
    [DefaultValue("0")]
    public bool IsActive { get; set; }

    public virtual ICollection<RoleAction> roleActions { get; set; } = null!;
    public virtual ICollection<RoleFeature> roleFeatures { get; set; } = null!;
    public virtual ICollection<RoleModule> roleModules { get; set; } = null!;

}


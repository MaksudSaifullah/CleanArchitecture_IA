using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Security;

[Table("RoleModule", Schema = "Security")]
public class RoleModule : EntityBase
{
    [Required]
    public Guid ModuleId { get; set; }
    [Required]
    public Guid RoleId { get; set; }


    [ForeignKey("ModuleId")]
    public virtual Module Module { get; set; } = null!;

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;
}


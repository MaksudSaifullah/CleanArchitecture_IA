using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities;

[Table("RoleAssignConfig", Schema = "")]
public class RoleAssignConfig : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid AuditRoleId { get; set; }

    [Required]
    public Guid RoleAssignConfigTypeId { get; set; }


    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;


/*    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;*/

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;


/*    [ForeignKey("AuditRoleId")]
    public virtual AuditRole AuditRole { get; set; } = null!;*/

    [ForeignKey("RoleAssignConfigTypeId")]
    public virtual RoleAssignConfigType RoleAssignConfigType { get; set; } = null!;

}
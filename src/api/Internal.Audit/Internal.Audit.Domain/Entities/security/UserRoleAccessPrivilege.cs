using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.security;

    [Table("UserRoleAccessPrivilege", Schema = "Security")]
    public class UserRoleAccessPrivilege : EntityBase
    {
    [Required]
    public Guid RoleId { get; set; }

    [Required]
    public Guid ModuleId { get; set; }

    [Required]
    public Guid FeatureId { get; set; }

    public Guid ActionId { get; set; }


    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("AuditModuleId")]
    public virtual AuditModule AuditModule { get; set; } = null!;

    [ForeignKey("AuditFeatureId")]
    public virtual AuditFeature AuditFeature { get; set; } = null!;

    [ForeignKey("AuditActionId")]
    public virtual AuditAction AuditAction { get; set; } = null!;

}


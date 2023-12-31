﻿using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAction = Internal.Audit.Domain.Entities.Common.AuditAction;

namespace Internal.Audit.Domain.Entities.Security;

[Table("RoleAction", Schema = "Security")]
public class RoleAction : EntityBase
{

    public Guid RoleId { get; set; }

    [Required]
    public Guid ActionId { get; set; }

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("ActionId")]
    public virtual AuditAction Action { get; set; } = null!;
}


﻿using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Security;

[Table("User", Schema = "Security")]
public class User : EntityBase
{

    [Required]
    [MaxLength(30)]
    public string UserName { get; set; } = null!;
    
    [MaxLength(80)]
    public string? FullName { get; set; }
    [MaxLength(512)]
    public string? ProfileImageUrl { get; set; }
    [Required]
    [MaxLength(100)]
    public string Password { get; set; } = null!;

    [Required]
    [DefaultValue("0")]
    public bool IsEnabled { get; set; }
    [Required]
    [DefaultValue("0")]
    public bool IsAccountExpired { get; set; }
    [Required]
    [DefaultValue("0")]
    public bool IsPasswordExpired { get; set; }
    [Required]
    [DefaultValue("0")]
    public bool IsAccountLocked { get; set; }

    //[ForeignKey("DesignationId")]
    //public virtual Designation Designation { get; set; } = null!;
    //Navigation properties
    public virtual ICollection<UserCountry> UserCountries { get; set; } = null!;
    public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
    public virtual Employee Employee { get; set; }

}


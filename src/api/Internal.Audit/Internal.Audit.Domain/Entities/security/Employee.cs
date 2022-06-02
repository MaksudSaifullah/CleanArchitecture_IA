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

[Table("Employee", Schema = "Security")]
public class Employee : EntityBase
{
    [Required]   
    public Guid UserId { get; set; }

    [Required]    
    public Guid DesignationId { get; set; }

    [Required]
    public Guid PhotoId { get; set; } //document foreign key

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
    [ForeignKey("DesignationId")]
    public virtual Designation Designation { get; set; } = null!;
    //[ForeignKey("PhotoId")]
    //public virtual Document Document { get; set; } = null!; //document need to be done


}

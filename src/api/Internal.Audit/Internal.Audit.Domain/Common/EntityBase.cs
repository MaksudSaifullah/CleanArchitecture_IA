
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Common;

public abstract class EntityBase
{   
    [Key]
    [Column("Id", TypeName = "uniqueidentifier")]
    [DefaultValue("newsequentialid()")]
    public Guid Id { get; set; }  //NEWSEQUENTIALID

    [Required]
    [MaxLength(10)]
    public string CreatedBy { get; set; } = null!;
    [Required]
    public DateTime CreatedOn { get; set; }
    
    [MaxLength(10)]
    public string? UpdatedBy { get; set; } = null!;
    public DateTime? UpdatedOn { get; set; }


    [MaxLength(10)]
    public string? ReviewedBy { get; set; }
    public DateTime? ReviewedOn { get; set; }

    
    [MaxLength(10)]
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedOn { get; set; }

    [Required]
    [DefaultValue("0")]
    public bool IsDeleted { get; set; }


    
	//[IsDeleted] [bit] NOT NULL DEFAULT(0)



}

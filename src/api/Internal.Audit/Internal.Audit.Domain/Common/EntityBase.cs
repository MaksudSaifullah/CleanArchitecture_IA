
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Common;

public abstract class EntityBase
{
    [Column("Id", TypeName = "NEWSEQUENTIALID()")]
    [Key]   
    public Guid Id { get; protected set; }  //NEWSEQUENTIALID

    [Required]
    [MaxLength(10)]
    public string CreatedBy { get; set; } = null!;
    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(10)]
    public string? UpdatedBy { get; set; } = null!;
    [Required]
    public DateTime? UpdatedOn { get; set; }


    [MaxLength(10)]
    public string? ReviewedBy { get; set; }
    public DateTime? ReviewedOn { get; set; }

    
    [MaxLength(10)]
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedOn { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }


    
	//[IsDeleted] [bit] NOT NULL DEFAULT(0)



}

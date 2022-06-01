using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("EmailBase", Schema = "")]
public class EmailBase : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }
    [Required]
    public Guid EmailTypeId { get; set; }
    [Required]
    [MaxLength(200)]
    public string SubjectTemplate { get; set; } = null!;
    [Required]
    [MaxLength(500)]
    public string BodyTemplate { get; set; } = null!;
    [Required]
    [DefaultValue(1)]
    public bool Status { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
    [ForeignKey("EmailTypeId")]
    public virtual EmailType EmailType { get; set; } = null!;    

}
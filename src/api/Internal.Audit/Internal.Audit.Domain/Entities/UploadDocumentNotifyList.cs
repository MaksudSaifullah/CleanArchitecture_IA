using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;

[Table("UploadDocumentNotifyList", Schema = "")]
public class UploadDocumentNotifyList : EntityBase
{
    [Required]
    public Guid DocumentId { get; set; }
    [Required]
    public Guid RoleId { get; set; }
    [Required]
    [DefaultValue(0)]
    public bool IsEmailSent { get; set; }

    //TODO
    //[ForeignKey("DocumentId")]
    //public virtual Document Document { get; set; } = null!;
    //[ForeignKey("RoleId")]
    //public virtual Role Role { get; set; } = null!;

}
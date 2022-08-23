using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.config;

[Table("UploadedDocumentsNotify", Schema = "Config")]
public class UploadedDocumentsNotify:EntityBase
{
    public Guid RoleId{ get; set; }
    [DefaultValue("0")]
    public bool IsMailSent { get; set; }
    [ForeignKey("RoleId")]
    public virtual Role UploadDocumentRoleList { get; set; } = null!;
}

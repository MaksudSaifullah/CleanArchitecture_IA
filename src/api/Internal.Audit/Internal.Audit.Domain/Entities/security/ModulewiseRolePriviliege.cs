using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security
{
    [Table("ModulewiseRolePriviliege", Schema = "Security")]
    public class ModulewiseRolePriviliege : EntityBase
    {
        [Required]
        public Guid AuditModuleId { get; set; }
        [Required]
        public Guid AuditFeatureId { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        public bool IsView { get; set; }
        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        [ForeignKey("AuditModuleId")]
        public virtual AuditModule AuditModule { get; set; }
        [ForeignKey("AuditFeatureId")]
        public virtual AuditFeature AuditFeature { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}

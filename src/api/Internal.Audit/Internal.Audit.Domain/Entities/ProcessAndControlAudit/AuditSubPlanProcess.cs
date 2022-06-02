using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit
{
    [Table("AuditSubPlanProcess", Schema = "ProcessAndControlAudit")]
    public class AuditSubPlanProcess : EntityBase
    {
        public Guid AuditSubPlanId { get; set; }
        public Guid AuditableFunctionId { get; set; }
        public Guid ProcessId { get; set; }
        public Guid RatingTypeId { get; set; }

        [Required]
        [DefaultValue("0")]
        public bool IsChecked { get; set; }


        [ForeignKey("AuditSubPlanId")]
        public virtual AuditSubPlan AuditSubPlan { get; set; } = null!;

        //[ForeignKey("AuditableFunctionId")]
        //public virtual AuditableFunction AuditableFunction { get; set; } = null!;

        //[ForeignKey("ProcessId")]
        //public virtual Process Process { get; set; } = null!;

        [ForeignKey("AuditPlanId")]
        public virtual AuditPlan AuditPlan { get; set; } = null!;

    }
}

using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.ProcessAndControlAudit
{
    [Table("AuditSubPlan", Schema = "ProcessAndControlAudit")]
    public class AuditSubPlan : EntityBase
    {
		public Guid AuditPlanId { get; set; }
		public Guid DurationTypeId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Code { get; set; } = null!;

		[Required]
		public DateTime ReviewPeriodFrom { get; set; }
		[Required]
		public DateTime ReviewPeriodTo { get; set; }

		[Required]
		public Int32 AvailableManDays { get; set; }

		[Required]
		public Int32 RequiredManDays { get; set; }

		[Required]
		public Int32 SurplusDeficit { get; set; }

		[Required]
		[MaxLength(50)]
		public string Rationale { get; set; } = null!;

		[ForeignKey("AuditPlanId")]
		public virtual AuditPlan AuditPlan { get; set; } = null!;

		[ForeignKey("DurationTypeId")]
		public virtual DurationType DurationType { get; set; } = null!;

	}
}

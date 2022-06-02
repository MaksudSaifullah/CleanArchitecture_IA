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
    [Table("AuditPlan", Schema = "ProcessAndControlAudit")]
    public class AuditPlan : EntityBase
    {

		public Guid CountryId { get; set; }

		public Guid AuditTypeId { get; set; }

		public Guid AuditYearId { get; set; }

		public Guid RiskAssessmentId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Code { get; set; } = null!;

		[Required]
		public DateTime ReviewFrom { get; set; }

		[Required]
		public DateTime ReviewTo { get; set; }


		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; } = null!;

		[ForeignKey("AuditTypeId")]
		public virtual AuditType AuditType { get; set; } = null!;

		[ForeignKey("AuditYearId")]
		public virtual AuditYear AuditYear { get; set; } = null!;

		[ForeignKey("RiskAssessmentId")]
		public virtual RiskAssessment RiskAssessment { get; set; } = null!;

	}
}

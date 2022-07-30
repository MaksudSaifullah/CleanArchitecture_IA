using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit
{
    [Table("AuditPlan", Schema = "BranchAudit")]
    public class AuditPlan : EntityBase
    {


        [Required]
        public Guid RiskAssesmentId { get; set; }

        [Required]
        [MaxLength(60)]
        public string PlanCode { get; set; } = null!;

        [Required]
        public Guid PlanningYearId { get; set; }

        [Required]
        public DateTime AssesmentFrom { get; set; }

        [Required]
        public DateTime AssesmentTo { get; set; }


        [ForeignKey("RiskAssesmentId")]
        public virtual RiskAssessment RiskAssesment { get; set; } = null!;
    }
}

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
    [Table("RCDDesign", Schema = "ProcessAndControlAudit")]
    public class RCDDesign : EntityBase
    {

        [Required]
        public Guid DETestScriptId { get; set; }

        [Required]
        public Guid ProcessId { get; set; }

        [Required]
        public Guid RiskId { get; set; }


        [Required]
        public Guid ControlId { get; set; }

        [Required]
        public Guid DETestConclusionId { get; set; }

        [Required]
        public DateTime FunctionName { get; set; }

        [Required]
        [MaxLength(20)]
        public string ControlDescription { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PolicyStandardsGuide { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string DETestSteps { get; set; } = null!;

        [Required]
        public string DETestResult { get; set; } = null!;

        [Required]
        public bool IsIssueIdentified { get; set; }

        [Required]
        [MaxLength(20)]
        public string IssueDetails { get; set; } = null!;

        [Required]
        public bool IsIssueReportable { get; set; }

        [Required]
        [MaxLength(20)]
        public string IssueEvidenceReference { get; set; } = null!;


        //[ForeignKey("DETestScriptId")]
        //public virtual DETestScript DETestScript { get; set; } = null!;

        [ForeignKey("ProcessId")]
        public virtual Process Process { get; set; } = null!;

        //[ForeignKey("RiskId")]
        //public virtual Risk Risk { get; set; } = null!;

        //[ForeignKey("ControlId")]
        //public virtual Control Control { get; set; } = null!;

       // [ForeignKey("DETestConclusionId")]
        //public virtual DETestConclusion DETestConclusion { get; set; } = null!;

    }
}

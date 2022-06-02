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
    [Table("OETestScript", Schema = "ProcessAndControlAudit")]
    internal class OETestScript : EntityBase
    {
        [Required]
        public Guid RceDEId { get; set; }
        [Required]
        public Guid SampleMonthId { get; set; }

        [Required]
        public Guid ControlActivityNatureId { get; set; }
        [Required]
        public Guid ControlFrequencyId { get; set; }

        [Required]
        public Guid SampleSelectionMethodId { get; set; }

        [Required]
        public Guid DocumentId { get; set; }      // foreign key


        [Required]
        [MaxLength(20)]
        public String OETestCode { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public String SampleName { get; set; } = null!;

        [Required]
        public DateTime DateofTesting { get; set; }

        [Required]
        public DateTime AuditPeriodFrom { get; set; }

        [Required]
        public DateTime AuditPeriodTo { get; set; }

        [Required]
        [MaxLength(200)]
        public String OETestSteps { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public String OETestResult { get; set; } = null!;


        [Required]
        [MaxLength(5)]
        public String OETestConclusion { get; set; } = null!;  // pass fail

        [Required]
        public bool IsIssueIdentified { get; set; }

        [Required]
        public bool IsIssueReportable { get; set; }

        [Required]
        [MaxLength(200)]
        public String IssueDetails { get; set; } = null!;


        [Required]
        [MaxLength(200)]
        public String IssueEvidenceReference { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public String Remarks { get; set; } = null!;



        //Navigation properties
        //[ForeignKey("RceDEId")]
        //public virtual RCDDesignPhase RCDDesignPhase { get; set; } = null!;

        //[ForeignKey("SampleMonthId")]
        //public virtual DurationType DurationType { get; set; } = null!; // foreign key

        [ForeignKey("ControlActivityNatureId")]
        public virtual ControlActivityNature ControlActivityNature { get; set; } = null!;

        [ForeignKey("ControlFrequencyId")]
        public virtual ControlFrequency ControlFrequency { get; set; } = null!; // foreign key


        //[ForeignKey("SampleSelectionMethodId")]
        //public virtual SampleSelectionMethodType SampleSelectionMethodType { get; set; } = null!; // foreign key


        //[ForeignKey("DocumentId")]
        //public virtual Document Document { get; set; } = null!; // foreign key
    }
}


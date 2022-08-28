using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("WorkPaper", Schema = "BranchAudit")]
public class WorkPaper : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string? WorkPaperCode { get; set; }
    [Required]
    public Guid AuditScheduleId { get; set; }
    [Required]
    public Guid TopicHeadId { get; set; }
    [Required]
    public Guid QuestionId { get; set; }
    [Required]
    public Guid AuditScheduleBranchId { get; set; }

    [Required]
    [MaxLength(300)]
    public string? SampleName { get; set; }

    [Required]
    public Guid SampleMonthId { get; set; }

    [Required]
    public Guid SampleSelectionMethodId { get; set; }

    [Required]
    public Guid ControlActivityNatureId { get; set; }

    [Required]
    public Guid ControlFrequencyId { get; set; }

    [Required]
    public Guid SampleSizeId { get; set; }


    [Required]
    [MaxLength(300)]
    public string? TestingDetails { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string? TestingResults { get; set; } = null!;

    [Required]
    public Guid TestingConclusionId { get; set; }

    [Required]
    public Guid DocumentId { get; set; }

    [Required]
    public DateTime TestingDate { get; set; }

    [ForeignKey("AuditScheduleId")]
    public virtual AuditSchedule? AuditSchedule { get; set; }

    [ForeignKey("TopicHeadId")]
    public virtual TopicHead TopicHead { get; set; }

    //[ForeignKey("DocumentId")]
    //public virtual Document? Document { get; set; }

    public virtual CommonValueAndType? CommonValueAndType { get; set; }

    //public virtual CommonValueAndType? CommonValueSampleSelection { get; set; } 
    //public virtual CommonValueAndType? CommonValueControlActivity { get; set; }
    //public virtual CommonValueAndType? CommonValueControlFrequency { get; set; }
    //public virtual CommonValueAndType? CommonValueSampleSize { get; set; }
}

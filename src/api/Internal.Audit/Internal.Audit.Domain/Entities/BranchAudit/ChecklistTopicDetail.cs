using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("ChecklistTopicDetails", Schema = "BranchAudit")]
public class ChecklistTopicDetail : EntityBase
{
    public Guid ChecklistTopicId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid TestStepId { get; set; }
    public Guid DocumentId { get; set; }

    public string? TestingResult { get; set; }

    public string? TestingConclusion { get; set; }

    public int TotalScore { get; set; }
    public int ObtainedScore { get; set; }
    public int Weight { get; set; }
    public int WeightedScore { get; set; }


    [ForeignKey("ChecklistTopicId")]
    public virtual ChecklistTopic ChecklistTopic { get; set; } = null!;

}

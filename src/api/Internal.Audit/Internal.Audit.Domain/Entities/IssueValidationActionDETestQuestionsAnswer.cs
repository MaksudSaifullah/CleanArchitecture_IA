using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities;
[Table("IssueValidationActionDETestQuestionsAnswer", Schema = "")]
public class IssueValidationActionDETestQuestionsAnswer : EntityBase
{
    [Required]    
    public Guid IssueValidationActionId { get; set; }
    [Required]
    public Guid DETestQuestionId { get; set; }
    [Required]
    public int Answer { get; set; }
    [MaxLength(200)]
    public string? Remarks { get; set; }

    [ForeignKey("IssueValidationActionId")]
    public virtual IssueValidationActionPlan IssueValidationActionPlan { get; set; } = null!;
    [ForeignKey("DETestQuestionId")]
    public virtual DETestQuestion DETestQuestion { get; set; } = null!;
}
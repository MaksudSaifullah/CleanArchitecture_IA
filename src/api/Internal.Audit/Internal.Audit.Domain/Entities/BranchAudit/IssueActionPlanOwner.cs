using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Internal.Audit.Domain.Entities.BranchAudit
{
    [Table("IssueActionPlanOwner", Schema = "BranchAudit")]
    public class IssueActionPlanOwner : EntityBase
    {
        [Required]
        public Guid IssueActionPlanId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey("IssueActionPlanId")]
        public virtual IssueActionPlan IssueActionPlan { get; set; } = null!;
    }
}
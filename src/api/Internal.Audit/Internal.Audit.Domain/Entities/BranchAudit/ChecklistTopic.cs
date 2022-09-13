using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;

[Table("ChecklistTopics", Schema = "BranchAudit")]
public class ChecklistTopic : EntityBase
{
    public Guid TopicHeadId { get; set; }

    public Guid ChecklistId { get; set; }

    [ForeignKey("TopicHeadId")]
    public virtual TopicHead TopicHead { get; set; } = null!;

    [ForeignKey("ChecklistId")]
    public virtual Checklist Checklist { get; set; } = null!;

    public virtual ICollection<ChecklistTopicDetail> ChecklistTopicHeadDetails { get; set; } = null!;
}

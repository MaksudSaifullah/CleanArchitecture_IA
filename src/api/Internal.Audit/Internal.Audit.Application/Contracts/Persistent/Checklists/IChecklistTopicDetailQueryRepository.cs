using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Checklists;

public interface IChecklistTopicDetailQueryRepository : IAsyncQueryRepository<ChecklistTopicDetail>
{
    Task<IEnumerable<ChecklistTopicDetail>> GetAllChecklistTopicDetailByChecklistTopicId(Guid checklistTopicId);
}

using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Checklists;


public class ChecklistTopicDetailCommandRepository : CommandRepositoryBase<ChecklistTopicDetail>, IChecklistTopicDetailCommandRepository
{
    public ChecklistTopicDetailCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

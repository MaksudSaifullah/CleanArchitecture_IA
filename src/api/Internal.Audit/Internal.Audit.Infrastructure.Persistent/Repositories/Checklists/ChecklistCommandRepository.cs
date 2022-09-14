using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Checklists;


public class ChecklistCommandRepository : CommandRepositoryBase<Checklist>, IChecklistCommandRepository
{
    public ChecklistCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

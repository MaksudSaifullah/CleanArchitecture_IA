using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.WorkPapers;


public class WorkPaperCommandRepository : CommandRepositoryBase<WorkPaper>, IWorkPaperCommandRepository
{
    public WorkPaperCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

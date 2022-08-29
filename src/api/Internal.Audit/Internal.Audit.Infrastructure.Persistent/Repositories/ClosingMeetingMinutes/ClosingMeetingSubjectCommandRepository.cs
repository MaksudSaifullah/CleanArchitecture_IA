using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;


public class ClosingMeetingSubjectCommandRepository : CommandRepositoryBase<ClosingMeetingSubject>, IClosingMeetingSubjectCommandRepository
{
    public ClosingMeetingSubjectCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

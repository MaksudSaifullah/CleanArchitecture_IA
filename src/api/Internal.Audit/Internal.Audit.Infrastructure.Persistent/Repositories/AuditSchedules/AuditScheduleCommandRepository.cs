using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleCommandRepository : CommandRepositoryBase<AuditSchedule>, IAuditScheduleCommandRepository
{
    public AuditScheduleCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditSchedules;

public interface IAuditScheduleBaseQueryRepository:IAsyncQueryRepository<AuditSchedule>
{
    Task<IEnumerable<AuditSchedule>> GetAuditScheduleById(Guid? Id);
    Task<IEnumerable<AuditSchedule>> GetAuditScheduleByCreationId(Guid? Id);
}

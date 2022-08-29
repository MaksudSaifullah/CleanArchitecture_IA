using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditSchedules;

public interface IAuditScheduleQueryRepository:IAsyncQueryRepository<CompositAuditSchedule>
{
    Task<(long, IEnumerable<CompositAuditSchedule>)> GetAll(string scheduleId, Guid auditCreationId, int pageSize, int pageNumber);
}

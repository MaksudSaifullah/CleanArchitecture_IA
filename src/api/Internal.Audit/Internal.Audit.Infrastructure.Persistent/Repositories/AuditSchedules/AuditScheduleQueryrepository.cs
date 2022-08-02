using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleQueryrepository : QueryRepositoryBase<AuditSchedule>, IAuditScheduleQueryRepository
{
    public AuditScheduleQueryrepository(string _connectionString) : base(_connectionString)
    {
    }

    public Task<IEnumerable<AuditSchedule>> GetList(Guid? PlanId)
    {
        throw new NotImplementedException();
    }
}

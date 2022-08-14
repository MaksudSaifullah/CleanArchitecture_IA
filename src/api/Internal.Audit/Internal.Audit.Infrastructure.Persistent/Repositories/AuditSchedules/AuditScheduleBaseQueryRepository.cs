using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleBaseQueryRepository : QueryRepositoryBase<AuditSchedule>, IAuditScheduleBaseQueryRepository
{
    public AuditScheduleBaseQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public Task<IEnumerable<AuditSchedule>> GetAuditScheduleById(Guid? Id)
    {
        throw new NotImplementedException();
    }
}

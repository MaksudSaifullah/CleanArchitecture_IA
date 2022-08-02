using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedulesParticipants;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedulesParticipants;

public class AuditScheduleparticipantsCommandRepository : CommandRepositoryBase<AuditScheduleParticipants>, IAuditScheduleParticipantsCommandRepository
{
    public AuditScheduleparticipantsCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

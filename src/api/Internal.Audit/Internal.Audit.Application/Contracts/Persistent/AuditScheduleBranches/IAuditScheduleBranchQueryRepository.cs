﻿using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;


public interface IAuditScheduleBranchQueryRepository : IAsyncQueryRepository<AuditScheduleBranch>
{
    Task<IEnumerable<AuditScheduleBranch>> GetByScheduleId(Guid id);
}
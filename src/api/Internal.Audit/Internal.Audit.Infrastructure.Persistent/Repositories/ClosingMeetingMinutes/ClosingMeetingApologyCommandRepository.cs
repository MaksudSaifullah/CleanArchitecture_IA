﻿using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;


public class ClosingMeetingApologyCommandRepository : CommandRepositoryBase<ClosingMeetingApology>, IClosingMeetingApologyCommandRepository
{
    public ClosingMeetingApologyCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}

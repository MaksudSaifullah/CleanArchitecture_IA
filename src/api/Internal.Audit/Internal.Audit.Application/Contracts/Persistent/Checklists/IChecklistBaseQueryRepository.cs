﻿using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Checklists;


public interface IChecklistBaseQueryRepository : IAsyncQueryRepository<Checklist>
{
    Task<Checklist> GetById(Guid id);
}

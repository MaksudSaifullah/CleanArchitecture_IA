﻿using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;

public interface IRiskAssesmentConsolidateDataCommandRepository:IAsyncCommandRepository<RiskAssesmentConsolidateData>
{
}

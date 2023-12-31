﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditPlanCodeList
{
    public record GetAuditPlanCodeListResponseDTO
    {
        public Guid Id { get; set; }
        public string PlanCode { get; set; }
    }
}

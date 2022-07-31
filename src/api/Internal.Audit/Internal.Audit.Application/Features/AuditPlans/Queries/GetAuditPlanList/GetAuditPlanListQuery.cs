﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanList
{
    public class GetAuditPlanListQuery : IRequest<AuditPlanListPagingDTO>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public dynamic searchTerm { get; set; }

    }
}

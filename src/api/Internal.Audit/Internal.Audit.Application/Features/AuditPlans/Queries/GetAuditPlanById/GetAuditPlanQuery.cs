using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Queries.GetAuditPlanById;
public record GetAuditPlanQuery(Guid Id) : IRequest<AuditPlanByIdDTO>;

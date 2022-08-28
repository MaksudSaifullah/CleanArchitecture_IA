using Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByCreationId;

public record GetAuditScheduleByCreationIdQuery(Guid? CreationId):IRequest<IEnumerable<GetAuditSchedulePlanIdResponseDTO>>;


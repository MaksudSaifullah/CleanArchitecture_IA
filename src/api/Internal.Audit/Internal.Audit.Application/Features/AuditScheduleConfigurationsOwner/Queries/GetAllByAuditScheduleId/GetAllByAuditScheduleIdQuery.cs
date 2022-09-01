using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetAllByAuditScheduleId;

public record GetAllByAuditScheduleIdQuery(Guid? AuditScheduleId,int TypeId):IRequest<GetAllByAuditScheduledIdResponseDTO>;


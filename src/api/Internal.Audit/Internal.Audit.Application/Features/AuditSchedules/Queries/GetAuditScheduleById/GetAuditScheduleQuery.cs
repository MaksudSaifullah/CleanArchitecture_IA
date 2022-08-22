using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleById;

public record GetAuditScheduleQuery(Guid Id) : IRequest<AuditScheduleByIdDTO>;

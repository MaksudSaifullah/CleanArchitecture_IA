﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;

public record GetAuditScheduleByPlanIdQuery(Guid? AuditSchduleId):IRequest<IEnumerable<GetAuditSchedulePlanIdResponseDTO>>;


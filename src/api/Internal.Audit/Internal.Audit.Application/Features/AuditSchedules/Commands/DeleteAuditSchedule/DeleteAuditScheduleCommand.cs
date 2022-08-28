using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;

public record DeleteAuditScheduleCommand(Guid Id):IRequest<DeleteAuditScheduleResponseDTO>;


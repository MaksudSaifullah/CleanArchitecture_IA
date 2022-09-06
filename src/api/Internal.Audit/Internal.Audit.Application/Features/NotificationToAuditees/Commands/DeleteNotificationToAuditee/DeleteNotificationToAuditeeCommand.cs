using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.DeleteNotificationToAuditee;

public record DeleteNotificationToAuditeeCommand(Guid Id) : IRequest<DeleteNotificationToAuditeeResponseDTO>;

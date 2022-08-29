using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.DeleteClosingMeetingMinute;

public record DeleteClosingMeetingMinuteCommand(Guid Id) : IRequest<DeleteClosingMeetingMinuteResponseDTO>;


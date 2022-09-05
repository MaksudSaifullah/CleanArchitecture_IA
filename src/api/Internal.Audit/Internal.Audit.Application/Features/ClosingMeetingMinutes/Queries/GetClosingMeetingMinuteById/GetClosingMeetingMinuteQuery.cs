using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteById;

public record GetClosingMeetingMinuteQuery(Guid Id) : IRequest<ClosingMeetingMinuteByIdDTO>;

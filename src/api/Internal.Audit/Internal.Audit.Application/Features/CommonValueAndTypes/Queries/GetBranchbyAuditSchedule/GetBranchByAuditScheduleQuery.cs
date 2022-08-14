using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetBranchbyAuditSchedule;

public record GetBranchByAuditScheduleQuery(Guid Id) : IRequest<IEnumerable<BranchByScheduleIdDTO>>;
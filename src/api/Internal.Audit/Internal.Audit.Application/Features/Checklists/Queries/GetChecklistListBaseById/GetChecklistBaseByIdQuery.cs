using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Queries.GetChecklistListBaseById;

public record GetChecklistBaseByIdQuery(Guid Id) : IRequest<GetChecklistBaseResponseDTO>;


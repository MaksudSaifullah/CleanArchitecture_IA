using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditById;
public record GetAuditQuery(Guid Id): IRequest<GetAuditByIdResponseDTO>;


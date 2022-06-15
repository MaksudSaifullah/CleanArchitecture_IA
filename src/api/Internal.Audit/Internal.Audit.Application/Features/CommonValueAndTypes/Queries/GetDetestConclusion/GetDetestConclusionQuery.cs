using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetDetestConclusion;
public record GetDetestConclusionQuery(Guid Id) : IRequest<DetestConclusionDTO>;



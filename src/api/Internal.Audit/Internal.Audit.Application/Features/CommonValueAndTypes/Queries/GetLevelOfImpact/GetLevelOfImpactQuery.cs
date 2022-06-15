using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfImpact;
public record GetLevelOfImpactQuery(Guid Id) : IRequest<LevelOfImpactDTO>;



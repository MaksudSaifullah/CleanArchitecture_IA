using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditScore;

public record GetAuditScoreQuery : IRequest<List<AuditScoreDTO>>
{

}
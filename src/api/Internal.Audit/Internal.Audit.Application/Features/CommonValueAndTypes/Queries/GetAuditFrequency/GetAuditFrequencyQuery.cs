using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetAuditFrequency;

public record GetAuditFrequencyQuery : IRequest<List<AuditFrequencyDTO>>
{

}
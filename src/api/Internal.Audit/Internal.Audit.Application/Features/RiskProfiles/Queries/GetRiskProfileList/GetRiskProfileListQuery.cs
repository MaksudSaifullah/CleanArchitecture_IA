using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList;
public class GetRiskProfileListQuery : IRequest<List<RiskProfileDTO>>
{
}

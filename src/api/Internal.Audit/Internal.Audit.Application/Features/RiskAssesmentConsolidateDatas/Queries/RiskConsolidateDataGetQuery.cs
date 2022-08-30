using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Queries;

public record RiskConsolidateDataGetQuery(Guid countryId,Guid riskAssesmentId,int pageNumber,int pageSize):IRequest<IEnumerable<RiskConsolidateDataGetQueryResponseDTO>>;


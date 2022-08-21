using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetRiskAssesmentData;

public record  GetRiskAssesmentDataQuery(DateTime? effectiveFrom, DateTime? effectiveTo, Guid? countryId, Guid? riskAssesmentId, int typeId, decimal conversionRate, int pageNumber, int pageSize) : IRequest<IEnumerable<GetRiskAssesmentDataQueryDTO>>;

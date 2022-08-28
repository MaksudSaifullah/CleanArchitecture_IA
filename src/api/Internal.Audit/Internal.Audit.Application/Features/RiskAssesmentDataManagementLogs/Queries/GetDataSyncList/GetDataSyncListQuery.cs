using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Queries.GetDataSyncList;

public record GetDataSyncListQuery(Guid? countryId, Guid? riskassesmentId, DateTime? FromDate, DateTime? ToDate, int typeId, decimal conversionRate, int pageNumber, int pageSize):IRequest<GetDataSyncListQueryResponseDTO>;



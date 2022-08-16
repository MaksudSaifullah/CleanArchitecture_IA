using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetRiskAssesmentData;

public class GetRiskAssesmentDataQueryHandler : IRequestHandler<GetRiskAssesmentDataQuery, IEnumerable<GetRiskAssesmentDataQueryDTO>>
{
    private readonly IRiskAssesmentDataManagementLogQueryRepository _dataSyncQueryRepository;
    private readonly IMapper _mapper;
    public GetRiskAssesmentDataQueryHandler(IRiskAssesmentDataManagementLogQueryRepository dataSyncQueryRepository, IMapper mapper)
    {
        _dataSyncQueryRepository = dataSyncQueryRepository ?? throw new ArgumentNullException(nameof(dataSyncQueryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<GetRiskAssesmentDataQueryDTO>> Handle(GetRiskAssesmentDataQuery request, CancellationToken cancellationToken)
    {
        var datas = await _dataSyncQueryRepository.GetDataSyncList(request.countryId,request.riskAssesmentId, request.effectiveFrom, request.effectiveTo, request.typeId, request.conversionRate, request.pageNumber, request.pageSize);
        var result = _mapper.Map<IEnumerable<GetRiskAssesmentDataQueryDTO>>(datas);
        return result;
    }
}

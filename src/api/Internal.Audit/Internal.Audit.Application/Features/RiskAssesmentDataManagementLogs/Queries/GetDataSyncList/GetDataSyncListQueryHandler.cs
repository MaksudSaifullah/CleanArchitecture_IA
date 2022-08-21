using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Queries.GetDataSyncList;

public class GetDataSyncListQueryHandler : IRequestHandler<GetDataSyncListQuery, GetDataSyncListQueryResponseDTO>
{
    private readonly IRiskAssesmentDataManagementLogQueryRepository _repositoryQuery;
    private readonly IRiskAssesmentDataManagementLogCommandRepository _repositoryCommand;
    private readonly IMapper _mapper;

    public GetDataSyncListQueryHandler(IRiskAssesmentDataManagementLogQueryRepository repositoryQuery,
        IRiskAssesmentDataManagementLogCommandRepository repositoryCommand, IMapper mapper)
    {
        _repositoryQuery = repositoryQuery ?? throw new ArgumentNullException(nameof(repositoryQuery));
        _repositoryCommand = repositoryCommand ?? throw new ArgumentNullException(nameof(repositoryCommand));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetDataSyncListQueryResponseDTO> Handle(GetDataSyncListQuery request, CancellationToken cancellationToken)
    {
        var dataExists = await _repositoryCommand.Get(x => x.RiskAssessmentId == request.riskassesmentId && x.TypeId == request.typeId);

        var dataRequestId =  dataExists.FirstOrDefault();
        if(dataRequestId != null)
        {

        }
        throw new NotImplementedException();
    }
}

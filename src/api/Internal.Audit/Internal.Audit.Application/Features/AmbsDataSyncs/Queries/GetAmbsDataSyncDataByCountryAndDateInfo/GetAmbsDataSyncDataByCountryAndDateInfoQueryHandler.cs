using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
using MediatR;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;

public class GetAmbsDataSyncDataByCountryAndDateInfoQueryHandler : IRequestHandler<GetAmbsDataSyncDataByCountryAndDateInfoQuery, IEnumerable<GetAmbsDataSyncDataByCountryAndDateInfoDTO>>
{
    private readonly IAmbsDataSyncQueryRepository _dataSyncQueryRepository;
    private readonly IMapper _mapper;
    public GetAmbsDataSyncDataByCountryAndDateInfoQueryHandler(IAmbsDataSyncQueryRepository dataSyncQueryRepository, IMapper mapper)
    {
        _dataSyncQueryRepository = dataSyncQueryRepository ?? throw new ArgumentNullException(nameof(dataSyncQueryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<GetAmbsDataSyncDataByCountryAndDateInfoDTO>> Handle(GetAmbsDataSyncDataByCountryAndDateInfoQuery request, CancellationToken cancellationToken)
    {
        var datas =await _dataSyncQueryRepository.GetDataSyncList( request.CountryId, request.startDate, request.endDate);
        var result = _mapper.Map<IEnumerable<GetAmbsDataSyncDataByCountryAndDateInfoDTO>>(datas);       
        return result;
    }
}

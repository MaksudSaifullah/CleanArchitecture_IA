using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetCommonValueTypeGeneric;
using MediatR;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetRiskRatingInfo;

public class GetRiskRatingInfoQueryHandler : IRequestHandler<GetRiskRatingInfoQuery, GetCommonValueTypeGenericDTO>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly IMapper _mapper;

    public GetRiskRatingInfoQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async  Task<GetCommonValueTypeGenericDTO> Handle(GetRiskRatingInfoQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndTypes = await _commonValueAndTypesRepository.GetRiskRatingType(request.ImpactTypeId,request.LikelihoodTypeId,request.Date);
        return _mapper.Map<GetCommonValueTypeGenericDTO>(commonValueAndTypes);
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfLikelihood;
public class GetLevelOfLikelihoodQueryHandler : IRequestHandler<GetLevelOfLikelihoodQuery, List<LevelOfLikelihoodDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly IMapper _mapper;

    public GetLevelOfLikelihoodQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<LevelOfLikelihoodDTO>> Handle(GetLevelOfLikelihoodQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndTypes = await _commonValueAndTypesRepository.GetAllLevelOfLikelihood();
        return _mapper.Map<List<LevelOfLikelihoodDTO>>(commonValueAndTypes);
    }
}

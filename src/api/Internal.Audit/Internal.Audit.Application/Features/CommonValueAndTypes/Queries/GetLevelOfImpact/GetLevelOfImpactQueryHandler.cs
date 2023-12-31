﻿using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetLevelOfImpact;
public class GetLevelOfImpactQueryHandler : IRequestHandler<GetLevelOfImpactQuery, List<LevelOfImpactDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly IMapper _mapper;

    public GetLevelOfImpactQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<LevelOfImpactDTO>> Handle(GetLevelOfImpactQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndTypes = await _commonValueAndTypesRepository.GetCommonValueType("LEVELOFIMPACT");
        return _mapper.Map<List<LevelOfImpactDTO>>(commonValueAndTypes);
    }
}

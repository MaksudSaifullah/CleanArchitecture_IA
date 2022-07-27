using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.WeightScoreConfigurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Queries.WeightScoreByCountryId;

public class GetWeightScoreQueryHandler : IRequestHandler<GetWeightScoreQuery, WeightScoreByCountryIdDTO>
{
    private readonly IWeightScoreConfigurationQueryRepository _weightScoreConfigurationQueryRepository;
    private readonly IMapper _mapper;

    public GetWeightScoreQueryHandler(IWeightScoreConfigurationQueryRepository weightScoreConfigurationQueryRepository, IMapper mapper)
    {
        _weightScoreConfigurationQueryRepository = weightScoreConfigurationQueryRepository ?? throw new ArgumentNullException(nameof(weightScoreConfigurationQueryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<WeightScoreByCountryIdDTO> Handle(GetWeightScoreQuery request, CancellationToken cancellationToken)
    {
        var weightScore = await _weightScoreConfigurationQueryRepository.GetByCountryId(request.countryId);
        return _mapper.Map<WeightScoreByCountryIdDTO>(weightScore);
    }
}

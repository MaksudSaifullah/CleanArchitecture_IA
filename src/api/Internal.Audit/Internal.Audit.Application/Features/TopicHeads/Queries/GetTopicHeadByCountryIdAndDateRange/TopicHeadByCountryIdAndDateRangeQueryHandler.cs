using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByCountryIdAndDateRange;

public class TopicHeadByCountryIdAndDateRangeQueryHandler : IRequestHandler<TopicHeadByCountryIdAndDateRangeQuery, IEnumerable<TopicHeadByCountryIdAndDateRangeDTO>>
{
    private readonly ITopicHeadQueryRepository _repository;
    private readonly IMapper _mapper;

    public TopicHeadByCountryIdAndDateRangeQueryHandler(ITopicHeadQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<TopicHeadByCountryIdAndDateRangeDTO>> Handle(TopicHeadByCountryIdAndDateRangeQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByCountryIdAnddateRange(request.countryId, request.FromDate,request.Todate);
        return _mapper.Map<IEnumerable<TopicHeadByCountryIdAndDateRangeDTO>>(result).ToList();
    }
}

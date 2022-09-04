using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList;

public class GetClosingMeetingMinuteListQueryHandler : IRequestHandler<GetClosingMeetingMinuteListQuery, ClosingMeetingMinuteListPagingDTO>
{
    private readonly IClosingMeetingMinutesQueryRepository _closingMeetingMinutesRepository;
    private readonly IMapper _mapper;

    public GetClosingMeetingMinuteListQueryHandler(IClosingMeetingMinutesQueryRepository closingMeetingMinutesRepository, IMapper mapper)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ClosingMeetingMinuteListPagingDTO> Handle(GetClosingMeetingMinuteListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<CompositeClosingMeetingMinute>) result = await _closingMeetingMinutesRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var closingMeetingMinuteList = _mapper.Map<List<ClosingMeetingMinuteDTO>>(result.Item2);

        return new ClosingMeetingMinuteListPagingDTO { Items = closingMeetingMinuteList, TotalCount = result.Item1 };
    }

   
}

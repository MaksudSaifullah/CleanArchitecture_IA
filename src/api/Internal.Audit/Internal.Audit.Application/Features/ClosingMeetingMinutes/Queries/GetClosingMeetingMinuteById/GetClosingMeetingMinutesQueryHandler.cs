using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteById;

public class GetClosingMeetingMinutesQueryHandler : IRequestHandler<GetClosingMeetingMinuteQuery, ClosingMeetingMinuteByIdDTO>
{
    private readonly IClosingMeetingMinutesQueryRepository _closingMeetingMinutesRepository;
    private readonly IMapper _mapper;

    public GetClosingMeetingMinutesQueryHandler(IClosingMeetingMinutesQueryRepository closingMeetingMinutesRepository, IMapper mapper)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ClosingMeetingMinuteByIdDTO> Handle(GetClosingMeetingMinuteQuery request, CancellationToken cancellationToken)
    {
        var closingMeetingMinute = await _closingMeetingMinutesRepository.GetById(request.Id);
        return _mapper.Map<ClosingMeetingMinuteByIdDTO>(closingMeetingMinute);
    }
}
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinutesBaseById;

public class GetClosingMeetingMinutesBaseByIdQueryHandler : IRequestHandler<GetClosingMeetingMinutesBaseByIdQuery, GetClosingMeetingMinutesResponseDTO>
{
    private readonly IClosingMeetingMinutesBaseQueryRepository _closingMeetingMinutesRepository;
    private readonly IMapper _mapper;

    public GetClosingMeetingMinutesBaseByIdQueryHandler(IClosingMeetingMinutesBaseQueryRepository closingMeetingMinutesRepository, IMapper mapper)
    {
        _closingMeetingMinutesRepository = closingMeetingMinutesRepository ?? throw new ArgumentNullException(nameof(closingMeetingMinutesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetClosingMeetingMinutesResponseDTO> Handle(GetClosingMeetingMinutesBaseByIdQuery request, CancellationToken cancellationToken)
    {
        var data =await _closingMeetingMinutesRepository.GetById(request.Id);
        return _mapper.Map<GetClosingMeetingMinutesResponseDTO>(data);
    }
}

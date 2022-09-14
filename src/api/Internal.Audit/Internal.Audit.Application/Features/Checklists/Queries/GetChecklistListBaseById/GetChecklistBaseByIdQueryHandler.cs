using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Checklists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Queries.GetChecklistListBaseById;


public class GetChecklistBaseByIdQueryHandler : IRequestHandler<GetChecklistBaseByIdQuery, GetChecklistBaseResponseDTO>
{
    private readonly IChecklistBaseQueryRepository _checklistBaseRepository;
    private readonly IMapper _mapper;

    public GetChecklistBaseByIdQueryHandler(IChecklistBaseQueryRepository checklistBaseRepository, IMapper mapper)
    {
        _checklistBaseRepository = checklistBaseRepository ?? throw new ArgumentNullException(nameof(checklistBaseRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<GetChecklistBaseResponseDTO> Handle(GetChecklistBaseByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _checklistBaseRepository.GetById(request.Id);
        return _mapper.Map<GetChecklistBaseResponseDTO>(data);
    }
}

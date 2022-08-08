using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperById;

public class GetWorkPaperQueryHandler : IRequestHandler<GetWorkPaperQuery, WorkPaperByIdDTO>
{
    private readonly IWorkPaperQueryRepository _workPaperRepository;
    private readonly IMapper _mapper;

    public GetWorkPaperQueryHandler(IWorkPaperQueryRepository workPaperRepository, IMapper mapper)
    {
        _workPaperRepository = workPaperRepository ?? throw new ArgumentNullException(nameof(workPaperRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<WorkPaperByIdDTO> Handle(GetWorkPaperQuery request, CancellationToken cancellationToken)
    {
        var workPaper = await _workPaperRepository.GetById(request.Id);
        return _mapper.Map<WorkPaperByIdDTO>(workPaper);
    }
}
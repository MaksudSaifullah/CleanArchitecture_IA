using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Queries.GetWorkPaperList;

public class GetWorkPaperListQueryHandler : IRequestHandler<GetWorkPaperListQuery, WorkPaperListPagingDTO>
{
    private readonly IWorkPaperQueryRepository _workPaperRepository;
    private readonly IMapper _mapper;

    public GetWorkPaperListQueryHandler(IWorkPaperQueryRepository workPaperRepository, IMapper mapper)
    {
        _workPaperRepository = workPaperRepository ?? throw new ArgumentNullException(nameof(workPaperRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<WorkPaperListPagingDTO> Handle(GetWorkPaperListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<CompositeWorkPaper>) result = await _workPaperRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var workPaperList = _mapper.Map<List<WorkPaperDTO>>(result.Item2);

        return new WorkPaperListPagingDTO { Items = workPaperList, TotalCount = result.Item1 };
    }
}
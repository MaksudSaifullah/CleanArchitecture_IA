using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Queries.GetChecklistList;

public class GetChecklistListQueryHandler : IRequestHandler<GetChecklistListQuery, ChecklistListPagingDTO>
{
    private readonly IChecklistQueryRepository _checklistRepository;
    private readonly IMapper _mapper;

    public GetChecklistListQueryHandler(IChecklistQueryRepository checklistRepository, IMapper mapper)
    {
        checklistRepository = checklistRepository ?? throw new ArgumentNullException(nameof(checklistRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ChecklistListPagingDTO> Handle(GetChecklistListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<CompositeChecklist>) result = await _checklistRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var checklistList = _mapper.Map<List<ChecklistDTO>>(result.Item2);

        return new ChecklistListPagingDTO { Items = checklistList, TotalCount = result.Item1 };
    }


}
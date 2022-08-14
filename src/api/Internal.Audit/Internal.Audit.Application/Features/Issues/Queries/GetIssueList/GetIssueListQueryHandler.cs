using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
public class GetIssueListQueryHandler : IRequestHandler<GetIssueListQuery, GetIssueListPagingDTO>
{
    private readonly IIssueQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetIssueListQueryHandler(IIssueQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetIssueListPagingDTO> Handle(GetIssueListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<Issue>) result = await _repository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var list = _mapper.Map<List<GetIssueListResponseDTO>>(result.Item2);

        return new GetIssueListPagingDTO { Items = list, TotalCount = result.Item1 };
    }
}
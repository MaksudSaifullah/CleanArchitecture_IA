using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepList;

public class GetTestStepListQueryHandler : IRequestHandler<GetTestStepListQuery, GetTestStepListPagingDTO>
{
    private readonly ITestStepQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetTestStepListQueryHandler(ITestStepQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetTestStepListPagingDTO> Handle(GetTestStepListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<CompositeTestStep>) result = await _repository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var list = _mapper.Map<List<GetTestStepListQueryResponseDTO>>(result.Item2);

        return new GetTestStepListPagingDTO { Items = list, TotalCount = result.Item1 };
    }
}
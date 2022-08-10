using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using MediatR;

namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueById;
public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, GetIssueByIdResponseDTO>
{
    private readonly IIssueQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetIssueByIdQueryHandler(IIssueQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetIssueByIdResponseDTO> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);
        return _mapper.Map<GetIssueByIdResponseDTO>(result);
    }
}
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.IssueValidations.Queries.GetIssueValidationByIssueId;

public class GetIssueValidationByIssueIdQueryHandler : IRequestHandler<GetIssueValidationByIssueIdQuery, IEnumerable<GetIssueValidationByIssueIdQueryResponseDTO>>
{
    private readonly IssueValidationQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetIssueValidationByIssueIdQueryHandler(IssueValidationQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<IEnumerable<GetIssueValidationByIssueIdQueryResponseDTO>> Handle(GetIssueValidationByIssueIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(request.IssueId);
        return _mapper.Map<IEnumerable<GetIssueValidationByIssueIdQueryResponseDTO>>(result);
    }
}

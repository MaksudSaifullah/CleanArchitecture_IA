using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using MediatR;

namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepById;
public class GetTestStepByIdQueryHandler : IRequestHandler<GetTestStepByIdQuery, GetTestStepByIdDTO>
{
    private readonly ITestStepQueryRepository _repository;
    private readonly IMapper _mapper;

    public GetTestStepByIdQueryHandler(ITestStepQueryRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<GetTestStepByIdDTO> Handle(GetTestStepByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetById(request.Id);
        return _mapper.Map<GetTestStepByIdDTO>(result);
    }
}

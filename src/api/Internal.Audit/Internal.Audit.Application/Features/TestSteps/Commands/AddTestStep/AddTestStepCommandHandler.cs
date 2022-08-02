using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;


namespace Internal.Audit.Application.Features.TestSteps.Commands.AddTestStep;
public class AddTestStepCommandHandler : IRequestHandler<AddTestStepCommand, AddTestStepResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITestStepCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddTestStepCommandHandler(ITestStepCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddTestStepResponseDTO> Handle(AddTestStepCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<TestStep>(request);
        var newquestionnaire = await _repository.Add(result);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddTestStepResponseDTO(newquestionnaire.Id, rowsAffected > 0, rowsAffected > 0 ? "Test Step Added Successfully!" : "Error while creating Test Step !");
    }

}

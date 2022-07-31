using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using MediatR;


namespace Internal.Audit.Application.Features.TestSteps.Commands.UpdateTestStep;
public class UpdateTestStepCommandHandler : IRequestHandler<UpdateTestStepCommand, UpdateTestStepResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITestStepCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTestStepCommandHandler(ITestStepCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateTestStepResponseDTO> Handle(UpdateTestStepCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get(request.Id);
        var mappedresult = _mapper.Map(request, result);
        var updatedmappedresult = await _repository.Update(mappedresult);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateTestStepResponseDTO(updatedmappedresult.Id, rowsAffected > 0, rowsAffected > 0 ? "Test Step Updated Successfully!" : "Error while updating Test Step!");
    }
}

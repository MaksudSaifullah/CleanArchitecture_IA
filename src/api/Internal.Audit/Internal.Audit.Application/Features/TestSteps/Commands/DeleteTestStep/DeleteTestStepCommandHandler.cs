using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using MediatR;

namespace Internal.Audit.Application.Features.TestSteps.Commands.DeleteTestStep;
public class DeleteTestStepCommandHandler : IRequestHandler<DeleteTestStepCommand, DeleteTestStepResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITestStepCommandRepository _repository;
    private readonly IMapper _mapper;

    public DeleteTestStepCommandHandler(ITestStepCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteTestStepResponseDTO> Handle(DeleteTestStepCommand request, CancellationToken cancellationToken)
    {
        var current = await _repository.Get(request.Id);        
        current.IsDeleted = true;
        var mapped = _mapper.Map(request, current);
        await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteTestStepResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Test Step Deleted Successfully!" : "Error while deleting Test Step!");
    }
}

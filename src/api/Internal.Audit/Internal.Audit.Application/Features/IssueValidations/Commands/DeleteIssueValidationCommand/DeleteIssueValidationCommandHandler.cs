using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using Internal.Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand;
using MediatR;

namespace Internal.Adit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand;

public class DeleteIssueValidationCommandHandler : IRequestHandler<Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand.DeleteIssueValidationCommand, DeleteIssueValidationCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IssueValidationCommandRepository _repository;
    private readonly IMapper _mapper;

    public DeleteIssueValidationCommandHandler(IssueValidationCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteIssueValidationCommandResponseDTO> Handle(Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand.DeleteIssueValidationCommand request, CancellationToken cancellationToken)
    {
        var issueValidation = await _repository.Get(request.Id);
        issueValidation.IsDeleted = true;

        var mapped = _mapper.Map(request, issueValidation);
        await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteIssueValidationCommandResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Validation Deleted Successfully!" : "Error while deleting Issue Validation!");
    }
}

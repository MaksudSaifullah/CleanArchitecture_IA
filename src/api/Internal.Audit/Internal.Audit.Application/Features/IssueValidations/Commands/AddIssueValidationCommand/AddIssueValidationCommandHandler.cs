using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.IssueValidations.Commands.AddIssueValidationCommand;

public class AddIssueValidationCommandHandler : IRequestHandler<AddIssueValidationCommand, AddIssueValidationCOmmandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IssueValidationCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddIssueValidationCommandHandler(IssueValidationCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddIssueValidationCOmmandResponseDTO> Handle(AddIssueValidationCommand request, CancellationToken cancellationToken)
    {
        var issue = _mapper.Map<IssueValidation>(request);
        var newIssueValidation = await _repository.Add(issue);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddIssueValidationCOmmandResponseDTO(newIssueValidation.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Validation Added Successfully!" : "Error while creating Issue Validation!");
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidations;
using MediatR;

namespace Internal.Audit.Application.Features.IssueValidations.Commands.UpdateIssueValidationCommand;

public class UpdateIssueValidationCommandHandler : IRequestHandler<UpdateIssueValidationCommand, UpdateIssueValdiationCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IssueValidationCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateIssueValidationCommandHandler(IssueValidationCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateIssueValdiationCommandResponseDTO> Handle(UpdateIssueValidationCommand request, CancellationToken cancellationToken)
    {
        var current = await _repository.Get(request.Id);
        var mapped = _mapper.Map(request, current);
        var updated = await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateIssueValdiationCommandResponseDTO(updated.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Validation Updated Successfully!" : "Error while updating Issue Validation!");
    }
}
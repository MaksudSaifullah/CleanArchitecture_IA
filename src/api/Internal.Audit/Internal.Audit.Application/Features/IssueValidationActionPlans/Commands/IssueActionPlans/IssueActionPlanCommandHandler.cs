using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlans;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.IssueActionPlans;

public class IssueActionPlanCommandHandler : IRequestHandler<IssueActionPlanCommand, IssueActionPlanCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueValidationActionPlanCommandRepository _repository;
    private readonly IMapper _mapper;

    public IssueActionPlanCommandHandler(IIssueValidationActionPlanCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<IssueActionPlanCommandResponseDTO> Handle(IssueActionPlanCommand request, CancellationToken cancellationToken)
    {
        var issue = _mapper.Map<IssueValidationActionPlan>(request);
        var newIssueValidation = await _repository.Add(issue);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new IssueActionPlanCommandResponseDTO(newIssueValidation.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Action Plan Added Successfully!" : "Error while creating Issue Action Plan!");
    }
}

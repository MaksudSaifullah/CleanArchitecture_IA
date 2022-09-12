using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using MediatR;


namespace Internal.Audit.Application.Features.Issues.Commands.UpdateIssue;
public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, UpdateIssueResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueCommandRepository _repository;
    private readonly IIssueActionPlanCommandRepository _actionPlanCommandRepository;
    private readonly IIssueBranchCommandRepository _branchCommandRepository;
    private readonly IIssueOwnerCommandRepository _ownerCommandRepository;
    private readonly IMapper _mapper;

    public UpdateIssueCommandHandler(IIssueCommandRepository repository, IIssueActionPlanCommandRepository actionPlanCommandRepository, 
        IIssueBranchCommandRepository branchCommandRepository, IIssueOwnerCommandRepository ownerCommandRepository,
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _actionPlanCommandRepository = actionPlanCommandRepository ?? throw new ArgumentNullException(nameof(actionPlanCommandRepository));
        _branchCommandRepository = branchCommandRepository ?? throw new ArgumentNullException(nameof(branchCommandRepository));
        _ownerCommandRepository = ownerCommandRepository ?? throw new ArgumentNullException(nameof(ownerCommandRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateIssueResponseDTO> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var current = await _repository.Get(request.Id);
        if (current == null)
            return new UpdateIssueResponseDTO(request.Id, false, "Invalid Issue Id");
        await _branchCommandRepository.Delete(_branchCommandRepository.Get(x => x.IssueId == request.Id).Result.ToList());
        await _ownerCommandRepository.Delete(_ownerCommandRepository.Get(x => x.IssueId == request.Id).Result.ToList());
        await _actionPlanCommandRepository.Delete(_actionPlanCommandRepository.Get(x => x.IssueId == request.Id).Result.ToList());

        var mapped = _mapper.Map(request, current);
        var updated = await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateIssueResponseDTO(updated.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Updated Successfully!" : "Error while updating Issue!");
    }
}
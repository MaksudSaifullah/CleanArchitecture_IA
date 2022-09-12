using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using MediatR;


namespace Internal.Audit.Application.Features.Issues.Commands.DeleteIssue;
public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, DeleteIssueResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueCommandRepository _repository;
    private readonly IMapper _mapper;

    public DeleteIssueCommandHandler(IIssueCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<DeleteIssueResponseDTO> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        if (hasDependency()) {
            return new DeleteIssueResponseDTO(request.Id, false, "Issue Has Dependency With Others! Delete The Child First");
        }
        var issue = await _repository.Get(request.Id);
        if (issue == null) {
            return new DeleteIssueResponseDTO(request.Id, false, "Invalid issue Id");
        }
        var mapped = _mapper.Map(request, issue);
        mapped.IsDeleted = true;
        await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteIssueResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Deleted Successfully!" : "Error while deleting Issue!");
    }
    public bool hasDependency()
    {
        return false;
    }
}
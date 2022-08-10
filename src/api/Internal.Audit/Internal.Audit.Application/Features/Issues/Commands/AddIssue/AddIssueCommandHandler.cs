using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;


namespace Internal.Audit.Application.Features.Issues.Commands.AddIssue;
public class AddIssueCommandHandler : IRequestHandler<AddIssueCommand, AddIssueResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddIssueCommandHandler(IIssueCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddIssueResponseDTO> Handle(AddIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = _mapper.Map<Issue>(request);
        var newIssue = await _repository.Add(issue);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddIssueResponseDTO(newIssue.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Added Successfully!" : "Error while creating Issue !");
    }

}

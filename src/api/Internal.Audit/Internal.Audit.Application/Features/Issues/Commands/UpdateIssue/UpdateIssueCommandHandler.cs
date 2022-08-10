using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Issues;
using MediatR;


namespace Internal.Audit.Application.Features.Issues.Commands.UpdateIssue;
public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, UpdateIssueResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateIssueCommandHandler(IIssueCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateIssueResponseDTO> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var current = await _repository.Get(request.Id);
        var mapped = _mapper.Map(request, current);
        var updated = await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateIssueResponseDTO(updated.Id, rowsAffected > 0, rowsAffected > 0 ? "Issue Updated Successfully!" : "Error while updating Issue!");
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.AddTopicHead;

public class AddTopicHeadCommandHandler : IRequestHandler<AddTopicHeadCommand, AddTopicHeadResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITopicHeadCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddTopicHeadCommandHandler(ITopicHeadCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddTopicHeadResponseDTO> Handle(AddTopicHeadCommand request, CancellationToken cancellationToken)
    {
        var topicHead = _mapper.Map<TopicHead>(request);
        var newTopicHead = await _repository.Add(topicHead);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddTopicHeadResponseDTO(newTopicHead.Id, rowsAffected > 0, rowsAffected > 0 ? "Topic Head Added Successfully!" : "Error while creating Topic Head!");
    }

}



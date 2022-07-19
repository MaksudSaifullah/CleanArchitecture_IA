using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.UpdateTopicHead;
public class UpdateTopicHeadCommandHandler : IRequestHandler<UpdateTopicHeadCommand, UpdateTopicHeadResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITopicHeadCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTopicHeadCommandHandler(ITopicHeadCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateTopicHeadResponseDTO> Handle(UpdateTopicHeadCommand request, CancellationToken cancellationToken)
    {
        var topicHead = await _repository.Get(request.Id);
        var mapped = _mapper.Map(request, topicHead);
        var updatedTopicHead = await _repository.Update(mapped);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateTopicHeadResponseDTO(updatedTopicHead.Id, rowsAffected > 0, rowsAffected > 0 ? "Topic Head Updated Successfully!" : "Error while updating topic head!");
    }
}

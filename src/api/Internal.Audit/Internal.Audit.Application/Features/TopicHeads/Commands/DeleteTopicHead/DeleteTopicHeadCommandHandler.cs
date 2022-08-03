using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using MediatR;

namespace Internal.Audit.Application.Features.TopicHeads.Commands.DeleteTopicHead;
public class DeleteTopicHeadCommandHandler : IRequestHandler<DeleteTopicHeadCommand, DeleteTopicHeadResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITopicHeadCommandRepository _repository;
    private readonly IQuestionnaireQueryRepository _repoQuestionnaire;
    private readonly IMapper _mapper;

    public DeleteTopicHeadCommandHandler(ITopicHeadCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IQuestionnaireQueryRepository repoQuestionnaire)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repoQuestionnaire = repoQuestionnaire ?? throw new ArgumentNullException(nameof(repoQuestionnaire));
    }
    public async Task<DeleteTopicHeadResponseDTO> Handle(DeleteTopicHeadCommand request, CancellationToken cancellationToken)
    {
        var questionnaire = await _repoQuestionnaire.GetByFilter("TopicHeadId", request.Id);
        if (questionnaire == null || questionnaire.ToList().Count == 0) {
            var topicHead = await _repository.Get(request.Id);
            topicHead.IsDeleted = true;
            var mapped = _mapper.Map(request, topicHead);
            await _repository.Update(mapped);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new DeleteTopicHeadResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Topic Head Deleted Successfully!" : "Error while deleting topic head!");
        }
        else
        {
            return new DeleteTopicHeadResponseDTO(request.Id, false, "Topic Head Has Dependency With Questionnaire! Delete The Child First");
        }
    }
}
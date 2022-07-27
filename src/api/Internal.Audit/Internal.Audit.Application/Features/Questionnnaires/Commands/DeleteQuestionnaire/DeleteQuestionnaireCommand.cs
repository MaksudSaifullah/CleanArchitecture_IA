using MediatR;


namespace Internal.Audit.Application.Features.Questionnnaires.Commands.DeleteQuestionnaire;
public class DeleteQuestionnaireCommand : IRequest<DeleteQuestionnaireResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteQuestionnaireCommand(Guid id)
    {
        Id = id;
    }
}


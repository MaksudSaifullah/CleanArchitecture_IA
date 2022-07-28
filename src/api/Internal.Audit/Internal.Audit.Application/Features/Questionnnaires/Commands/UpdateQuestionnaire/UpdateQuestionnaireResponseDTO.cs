using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Questionnnaires.Commands.UpdateQuestionnaire;
public record UpdateQuestionnaireResponseDTO : BaseResponseDTO
{
    public UpdateQuestionnaireResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

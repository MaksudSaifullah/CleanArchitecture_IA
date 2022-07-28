using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.Questionnnaires.Commands.AddQuestionnaire;
public record AddQuestionnaireResponseDTO : BaseResponseDTO
{
    public AddQuestionnaireResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
using Internal.Audit.Application.Common;


namespace Internal.Audit.Application.Features.TestSteps.Commands.DeleteTestStep;
public record DeleteTestStepResponseDTO : BaseResponseDTO
{
    public DeleteTestStepResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
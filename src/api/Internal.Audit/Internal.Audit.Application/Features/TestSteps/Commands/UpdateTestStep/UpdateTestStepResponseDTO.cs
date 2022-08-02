
using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.TestSteps.Commands.UpdateTestStep;

public record UpdateTestStepResponseDTO : BaseResponseDTO
{
    public UpdateTestStepResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


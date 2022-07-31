
using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.TestSteps.Commands.AddTestStep;
public record AddTestStepResponseDTO : BaseResponseDTO
{
    public AddTestStepResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}

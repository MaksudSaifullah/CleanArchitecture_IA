using MediatR;

namespace Internal.Audit.Application.Features.TestSteps.Commands.AddTestStep;
public class AddTestStepCommand : IRequest<AddTestStepResponseDTO>
{
    public Guid QuestionnaireId { get; set; }
    public string TestStepDetails { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}
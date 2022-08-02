using MediatR;


namespace Internal.Audit.Application.Features.TestSteps.Commands.UpdateTestStep;
public class UpdateTestStepCommand : IRequest<UpdateTestStepResponseDTO>
{
    public Guid Id { get; set; }
    public Guid QuestionnaireId { get; set; }
    public string TestStepDetails { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}

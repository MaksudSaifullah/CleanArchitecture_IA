using MediatR;


namespace Internal.Audit.Application.Features.TestSteps.Commands.DeleteTestStep;
public class DeleteTestStepCommand : IRequest<DeleteTestStepResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteTestStepCommand(Guid id)
    {
        Id = id;
    }
}
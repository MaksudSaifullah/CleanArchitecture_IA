using MediatR;


namespace Internal.Audit.Application.Features.TestSteps.Queries.GetTestStepById;
public record GetTestStepByIdQuery(Guid Id) : IRequest<GetTestStepByIdDTO>;

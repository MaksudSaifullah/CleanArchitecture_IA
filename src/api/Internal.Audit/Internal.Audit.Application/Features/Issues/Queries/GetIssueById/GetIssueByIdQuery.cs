using MediatR;


namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueById;
public record GetIssueByIdQuery(Guid Id) : IRequest<GetIssueByIdResponseDTO>;

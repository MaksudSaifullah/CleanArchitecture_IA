using MediatR;

namespace Internal.Audit.Application.Features.IssueValidations.Commands.DeleteIssueValidationCommand;

public record DeleteIssueValidationCommand(Guid Id) :IRequest<DeleteIssueValidationCommandResponseDTO>;

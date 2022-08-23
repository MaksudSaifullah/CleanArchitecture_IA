using MediatR;

namespace Internal.Audit.Application.Features.UploadDocuments.Commands.DeleteUploadDocument;

public record DeleteUploadDocumentCommand(Guid Id):IRequest<DeleteUploadDocumentResponseDTO>;


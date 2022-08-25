using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Documents;
using MediatR;

namespace Internal.Audit.Application.Features.Documents.Commands.UpdateDocumentCommand;

public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, UpdateDocumentCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDocumentCommandRepository _documentRepository;
    private readonly IMapper _mapper;

    public UpdateDocumentCommandHandler(IDocumentCommandRepository documentRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateDocumentCommandDTO> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await _documentRepository.Get(request.Id);
        var mappeddocument = _mapper.Map(request, document);
        if (mappeddocument != null )
        {
            if(request.File?.Length > 0)
            {
                var (isUploaded, path, format, fileName) = await _documentRepository.UploadFile(request.File, request.DocumentSourceName);
                if (isUploaded)
                {
                    if (string.IsNullOrWhiteSpace(request.Name))
                    {
                        request.Name = fileName;
                    }
                    mappeddocument.Path = path;
                    mappeddocument.Format = format;                   
                }
            }
            var documentUpdated = await _documentRepository.Update(mappeddocument);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new UpdateDocumentCommandDTO(documentUpdated.Id, rowsAffected > 0, rowsAffected > 0 ? "Document updated Successfully!" : "Error while updating document !");

        }
        return new UpdateDocumentCommandDTO(Guid.NewGuid(), false, "Error while updating document!");

    }
}

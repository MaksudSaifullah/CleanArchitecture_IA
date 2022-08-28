using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Documents;
using Internal.Audit.Domain.Entities.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Commands.AddDocumentCommand;

public class AddDocumentCommandHandler : IRequestHandler<AddDocumentCommand, AddDocumentCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDocumentCommandRepository _documentRepository;
    private readonly IMapper _mapper;

    public AddDocumentCommandHandler(IDocumentCommandRepository documentRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddDocumentCommandResponseDTO> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
    {
        var (isUploaded,path,format,fileName) =await _documentRepository.UploadFile(request.File,request.DocumentSourceName);
        //request.Name = request.Name.Replace(" ", "%20");
        if (isUploaded)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                request.Name = fileName;
            }
            var documentModel = _mapper.Map<Document>(request);
            documentModel.Path = path;
            documentModel.Format = format;
            var document = await _documentRepository.Add(documentModel);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new AddDocumentCommandResponseDTO(document.Id, rowsAffected > 0, rowsAffected > 0 ? "Document uploaded Successfully!" : "Error while uploading document !");

        }

        return new AddDocumentCommandResponseDTO(Guid.NewGuid(), false, "Error while uploading document!");

    }
}

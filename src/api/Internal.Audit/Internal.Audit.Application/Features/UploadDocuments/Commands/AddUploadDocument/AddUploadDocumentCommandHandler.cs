using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using Internal.Audit.Domain.Entities.config;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Commands.AddUploadDocument;

public class AddUploadDocumentCommandHandler : IRequestHandler<AddUploadDocumentCommand, AddUploadDocumentResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUploadDocumentCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddUploadDocumentCommandHandler(IUploadDocumentCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddUploadDocumentResponseDTO> Handle(AddUploadDocumentCommand request, CancellationToken cancellationToken)
    {
        var UploadDocument = _mapper.Map<UploadDocument>(request);
        var newUploadDocument = await _repository.Add(UploadDocument);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddUploadDocumentResponseDTO(newUploadDocument.Id, rowsAffected > 0, rowsAffected > 0 ? "Document Added Successfully!" : "Error while adding Document!");
    }
}

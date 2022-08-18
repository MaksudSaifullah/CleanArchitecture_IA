using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Commands.DeleteUploadDocument;

public class DeleteUploadDocumentCommandHandler : IRequestHandler<DeleteUploadDocumentCommand, DeleteUploadDocumentResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUploadDocumentCommandRepository _repository;
    private readonly IMapper _mapper;

    public DeleteUploadDocumentCommandHandler(IUploadDocumentCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
       
    }
    public async Task<DeleteUploadDocumentResponseDTO> Handle(DeleteUploadDocumentCommand request, CancellationToken cancellationToken)
    {
        var existsData = await _repository.Get(x => x.Id == request.Id);
        if (existsData.FirstOrDefault() != null)
        {
            existsData.FirstOrDefault().IsDeleted = true;
            await _repository.Update(existsData);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new DeleteUploadDocumentResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Document Deleted Successfully!" : "Error while deleting document!");
        }
        return new DeleteUploadDocumentResponseDTO(request.Id, false,  "Error while deleting document!");

    }
}

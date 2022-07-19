using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Documents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Commands.DeleteDocumentCommand
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, DeleteDocumentCommandDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentCommandRepository _documentRepository;
        private readonly IMapper _mapper;

        public DeleteDocumentCommandHandler(IDocumentCommandRepository documentRepository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<DeleteDocumentCommandDTO> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.Get(request.Id);
            document.IsDeleted = true;
            var mappeddocument = _mapper.Map(request, document);           
            await _documentRepository.Update(mappeddocument);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new DeleteDocumentCommandDTO(mappeddocument.Id, rowsAffected > 0, rowsAffected > 0 ? "Document deleted Successfully!" : "Error while deleting Document!");

        }
    }
}

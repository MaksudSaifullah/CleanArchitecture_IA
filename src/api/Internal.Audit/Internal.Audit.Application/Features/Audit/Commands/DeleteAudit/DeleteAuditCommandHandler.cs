using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Commands.DeleteAudit
{
    public class DeleteAuditCommandHandler : IRequestHandler<DeleteAuditCommand, DeleteAuditResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditCommandRepository _auditRepository;
        private readonly IMapper _mapper;

        public DeleteAuditCommandHandler(IAuditCommandRepository auditRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _auditRepository = auditRepository ?? throw new ArgumentNullException(nameof(auditRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<DeleteAuditResponseDTO> Handle(DeleteAuditCommand request, CancellationToken cancellationToken)
        {
            var audit = await _auditRepository.Get(request.Id);
            audit.IsDeleted = true;
            var mappedAudit = _mapper.Map(request, audit);
            await _auditRepository.Update(mappedAudit);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new DeleteAuditResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Deleted Successfully!" : "Error while deleting Audit!");
        }
    }
}

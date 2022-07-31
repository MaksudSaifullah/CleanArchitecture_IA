using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Commands.UpdateAudit
{
    public class UpdateAuditCommandHandler : IRequestHandler<UpdateAuditCommand, UpdateAuditResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditCommandRepository _auditRepository;
        private readonly IMapper _mapper;
        public UpdateAuditCommandHandler(IAuditCommandRepository auditRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _auditRepository = auditRepository ?? throw new ArgumentNullException(nameof(auditRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<UpdateAuditResponseDTO> Handle(UpdateAuditCommand request, CancellationToken cancellationToken)
        {
            var audit = await _auditRepository.Get(request.Id);
            var mappedAudit = _mapper.Map(request, audit);
            var updatedAudit = await _auditRepository.Update(mappedAudit);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new UpdateAuditResponseDTO(updatedAudit.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Updated Successfully!" : "Error while updating Audit!");
        }
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Commands.AddAudit
{
    public class AddAuditCommandHandler : IRequestHandler<AddAuditCommand, AddAuditResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditCommandRepository _auditRepository;
        private readonly IMapper _mapper;
        public AddAuditCommandHandler(IAuditCommandRepository auditRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
        {
            _auditRepository = auditRepository ?? throw new ArgumentNullException(nameof(auditRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<AddAuditResponseDTO> Handle(AddAuditCommand request, CancellationToken cancellationToken)
        {
            var audit = _mapper.Map<AuditCreation>(request);
            var newAudit = await _auditRepository.Add(audit);
            var rowsAffected = await _unitOfWork.CommitAsync();

            return new AddAuditResponseDTO(newAudit.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Added Successfully!" : "Error while creating Audit!");
        }
    }
}

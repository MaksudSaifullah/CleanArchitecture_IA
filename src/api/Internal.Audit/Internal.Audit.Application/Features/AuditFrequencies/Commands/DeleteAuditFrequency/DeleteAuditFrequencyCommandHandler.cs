using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Commands.DeleteAuditFrequency;

public class DeleteAuditFrequencyCommandHandler : IRequestHandler<DeleteAuditFrequencyCommand, DeleteAuditFrequencyResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditFrequencyCommandRepository _auditfrequencyRepository;
    
    private readonly IMapper _mapper;

public DeleteAuditFrequencyCommandHandler(IAuditFrequencyCommandRepository auditfrequencyRepository, IMapper mapper, IUnitOfWork unitOfWork)
{
     _auditfrequencyRepository = auditfrequencyRepository ?? throw new ArgumentNullException(nameof(auditfrequencyRepository));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
}

public async Task<DeleteAuditFrequencyResponseDTO> Handle(DeleteAuditFrequencyCommand request, CancellationToken cancellationToken)
{
    var auditFrequency = await _auditfrequencyRepository.Get(request.Id);       
    auditFrequency.IsDeleted = true;
    var mappedauditFrequency = _mapper.Map(request, auditFrequency);
    await _auditfrequencyRepository.Update(mappedauditFrequency);
    var rowsAffected = await _unitOfWork.CommitAsync();
    return new DeleteAuditFrequencyResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Frequency Deleted Successfully!" : "Error while deleting Audit Frequency!");
}
}

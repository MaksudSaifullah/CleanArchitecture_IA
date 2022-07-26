using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Commands.AddAuditFrequency;

public class AddAuditFrequencyCommandHandler : IRequestHandler<AddAuditFrequencyCommand, AddAuditFrequencyResponseDTO>
{
private readonly IUnitOfWork _unitOfWork;
private readonly IAuditFrequencyCommandRepository _auditfrequencyRepository;
private readonly IMapper _mapper;

public AddAuditFrequencyCommandHandler(IAuditFrequencyCommandRepository auditfrequencyRepository, IMapper mapper,
    IUnitOfWork unitOfWork)
{
    _auditfrequencyRepository = auditfrequencyRepository ?? throw new ArgumentNullException(nameof(auditfrequencyRepository));
    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
}
public async Task<AddAuditFrequencyResponseDTO> Handle(AddAuditFrequencyCommand request, CancellationToken cancellationToken)
{
    var auditFrequency = _mapper.Map<AuditFrequency>(request);
    var newauditFrequency = await _auditfrequencyRepository.Add(auditFrequency);
    var rowsAffected = await _unitOfWork.CommitAsync();

    return new AddAuditFrequencyResponseDTO(newauditFrequency.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Frequency Added Successfully!" : "Error while creating Audit Frequency !");
}

}


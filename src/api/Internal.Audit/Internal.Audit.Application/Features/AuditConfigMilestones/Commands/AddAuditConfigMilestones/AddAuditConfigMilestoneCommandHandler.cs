using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditConfigMilestones;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditConfigMilestones.Commands.AddAuditConfigMilestones;

public class AddAuditConfigMilestoneCommandHandler : IRequestHandler<AddAuditConfigMilestoneCommand, AddAuditConfigMilestoneResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditConfigMilestoneCommandReposiotry _auditConfigRepository;
    private readonly IMapper _mapper;
    public AddAuditConfigMilestoneCommandHandler(IAuditConfigMilestoneCommandReposiotry auditConfigRepository, IMapper mapper,
    IUnitOfWork unitOfWork)
    {
        _auditConfigRepository = auditConfigRepository ?? throw new ArgumentNullException(nameof(auditConfigRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddAuditConfigMilestoneResponseDTO> Handle(AddAuditConfigMilestoneCommand request, CancellationToken cancellationToken)
    {
        var existsDataList = await _auditConfigRepository.Get(x => x.AuditScheduleId == request.Data.FirstOrDefault().AuditScheduleId);
        if (existsDataList != null)
        {
            await _auditConfigRepository.Delete(existsDataList);
        }
        var audit = _mapper.Map<IEnumerable<AuditConfigMileStone>>(request.Data);
        var newAudit = await _auditConfigRepository.Add(audit);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddAuditConfigMilestoneResponseDTO(Guid.NewGuid(), rowsAffected > 0, rowsAffected > 0 ? "Audit Config Milestone saved Successfully!" : "Error while creating Audit Config Milestone!");
       
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Commands.AddAuditScheduleConfigurationsOwnerCommand;

public class AddAuditScheduleConfigurationsOwnerCommandHandler : IRequestHandler<AddAuditScheduleConfigurationsOwnerCommand, AuditScheduleConfiurationsOwnerCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditScheduleConfigurationOwnerCommandRepository _auditscheduleRepository;
    private readonly IMapper _mapper;

    public AddAuditScheduleConfigurationsOwnerCommandHandler(IAuditScheduleConfigurationOwnerCommandRepository auditscheduleRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _auditscheduleRepository = auditscheduleRepository ?? throw new ArgumentNullException(nameof(auditscheduleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        
    }
    public async Task<AuditScheduleConfiurationsOwnerCommandResponseDTO> Handle(AddAuditScheduleConfigurationsOwnerCommand request, CancellationToken cancellationToken)
    {
        var existsDataList = await _auditscheduleRepository.Get(x => x.AuditScheduleId == request.Data.FirstOrDefault().AuditScheduleId && x.BranchId== request.Data.FirstOrDefault().BranchId && x.CommonValueAuditScheduleRiskOwnerTypetId == request.Data.FirstOrDefault().CommonValueAuditScheduleRiskOwnerTypetId);
        if (existsDataList != null)
        {
            await _auditscheduleRepository.Delete(existsDataList);
        }
        var configurationsOwner = _mapper.Map<IEnumerable<AuditScheduleConfigurationOwner>>(request.Data);        
        await _auditscheduleRepository.Add(configurationsOwner);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AuditScheduleConfiurationsOwnerCommandResponseDTO(Guid.NewGuid(), rowsAffected > 0, rowsAffected > 0 ? "Audit Schedule Confiurations Owner created Successfully!" : "Error while creating AuditAudit Schedule Confiurations Owner !");

    }
}

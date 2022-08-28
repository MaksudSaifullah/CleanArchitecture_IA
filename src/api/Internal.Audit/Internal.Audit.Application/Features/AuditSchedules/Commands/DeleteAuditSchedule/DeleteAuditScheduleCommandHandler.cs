using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditScheduleBranches;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedulesParticipants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.DeleteAuditSchedule;

public class DeleteAuditScheduleCommandHandler : IRequestHandler<DeleteAuditScheduleCommand, DeleteAuditScheduleResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditScheduleCommandRepository _auditscheduleRepository;
    private readonly IAuditScheduleParticipantsCommandRepository _auditscheduleparticipantRepository;
    private readonly IAuditScheduleBranchCommandRepository _auditscheduleBranchRepository;
    private readonly IMapper _mapper;

    public DeleteAuditScheduleCommandHandler(IAuditScheduleCommandRepository auditscheduleRepository, IMapper mapper,
        IUnitOfWork unitOfWork, IAuditScheduleParticipantsCommandRepository auditscheduleparticipantRepository, IAuditScheduleBranchCommandRepository auditscheduleBranchRepository)
    {
        _auditscheduleRepository = auditscheduleRepository ?? throw new ArgumentNullException(nameof(auditscheduleRepository));
        _auditscheduleBranchRepository = auditscheduleBranchRepository ?? throw new ArgumentNullException(nameof(auditscheduleBranchRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _auditscheduleparticipantRepository = auditscheduleparticipantRepository ?? throw new ArgumentNullException(nameof(auditscheduleparticipantRepository));
    }
    public async Task<DeleteAuditScheduleResponseDTO> Handle(DeleteAuditScheduleCommand request, CancellationToken cancellationToken)
    {
        var auditSchedule = await _auditscheduleRepository.Get(request.Id);
        if (auditSchedule == null)
            return new DeleteAuditScheduleResponseDTO(request.Id, false, "Invalid audit schedule Id");
        //await _auditscheduleparticipantRepository.Delete(_auditscheduleparticipantRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());
        //await _auditscheduleBranchRepository.Delete(_auditscheduleBranchRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());

        var mixed = _mapper.Map(request, auditSchedule);
        mixed.IsDeleted = true;
        //await _auditscheduleparticipantRepository.Delete(_auditscheduleparticipantRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());
        //await _auditscheduleBranchRepository.Delete(_auditscheduleBranchRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());

        await _auditscheduleRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteAuditScheduleResponseDTO(request.Id, rowsAffected > 0, "Audit schedule Id deleted successfully");

    }
}

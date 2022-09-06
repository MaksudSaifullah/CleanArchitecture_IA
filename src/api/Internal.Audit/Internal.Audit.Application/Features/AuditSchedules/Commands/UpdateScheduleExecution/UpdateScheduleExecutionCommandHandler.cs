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

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateScheduleExecution;

public class UpdateScheduleExecutionCommandHandler : IRequestHandler<UpdateScheduleExecutionCommand, UpdateScheduleExecutionCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditScheduleCommandRepository _auditscheduleRepository;
    private readonly IAuditScheduleParticipantsCommandRepository _auditscheduleparticipantRepository;
    private readonly IAuditScheduleBranchCommandRepository _auditscheduleBranchRepository;
    private readonly IMapper _mapper;

    public UpdateScheduleExecutionCommandHandler(IAuditScheduleCommandRepository auditscheduleRepository, IMapper mapper,
        IUnitOfWork unitOfWork, IAuditScheduleParticipantsCommandRepository auditscheduleparticipantRepository, IAuditScheduleBranchCommandRepository auditscheduleBranchRepository)
    {
        _auditscheduleRepository = auditscheduleRepository ?? throw new ArgumentNullException(nameof(auditscheduleRepository));
        _auditscheduleBranchRepository = auditscheduleBranchRepository ?? throw new ArgumentNullException(nameof(auditscheduleBranchRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _auditscheduleparticipantRepository = auditscheduleparticipantRepository ?? throw new ArgumentNullException(nameof(auditscheduleparticipantRepository));
    }
    public async Task<UpdateScheduleExecutionCommandResponseDTO> Handle(UpdateScheduleExecutionCommand request, CancellationToken cancellationToken)
    {
        var auditSchedule = await _auditscheduleRepository.Get(request.Id);
        if (auditSchedule == null)
            return new UpdateScheduleExecutionCommandResponseDTO(request.Id, false, "Invalid audit schedule Id");
        if(request.ScheduleState != -1)
        {
            auditSchedule.ScheduleState = request.ScheduleState;    
        }
        if (request.ExecutionState != -1)
        {
            auditSchedule.ExecutionState = request.ExecutionState;
        }
        await _auditscheduleRepository.Update(auditSchedule);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateScheduleExecutionCommandResponseDTO(request.Id, rowsAffected > 0, "Updated audit schedule");

    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Application.Contracts.Persistent.AuditSchedulesParticipants;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;

public class AddAuditScheduleCommandHandler : IRequestHandler<AddAuditScheduleCommand, AddAuditScheduleResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditScheduleCommandRepository _auditscheduleRepository;
    private readonly IAuditScheduleParticipantsCommandRepository _auditscheduleparticipantRepository;
    private readonly IMapper _mapper;

    public AddAuditScheduleCommandHandler(IAuditScheduleCommandRepository auditscheduleRepository, IMapper mapper,
        IUnitOfWork unitOfWork, IAuditScheduleParticipantsCommandRepository auditscheduleparticipantRepository)
    {
        _auditscheduleRepository = auditscheduleRepository ?? throw new ArgumentNullException(nameof(auditscheduleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _auditscheduleparticipantRepository = auditscheduleparticipantRepository ?? throw new ArgumentNullException(nameof(auditscheduleparticipantRepository));
    }
    public async Task<AddAuditScheduleResponseDTO> Handle(AddAuditScheduleCommand request, CancellationToken cancellationToken)
    {
        var gid = Guid.NewGuid();
        request.Id = gid;

        var maxScheduleIdresult = await _auditscheduleRepository.Get(x => x.AuditCreationId == request.AuditCreationId);
        var existsCount = maxScheduleIdresult.Count();

        var scheduleSet = _mapper.Map<AuditSchedule>(request);
        scheduleSet.ScheduleId = request.ScheduleEndDate.Year.ToString() + (existsCount + 1).ToString();
        await _auditscheduleRepository.Add(scheduleSet);

        //request.AuditScheduleParticipants.ForEach(x => x.AuditScheduleId = gid);
        //var scheduleParticipants = _mapper.Map<IList<AuditScheduleParticipants>>(request.AuditScheduleParticipants);
        //await _auditscheduleparticipantRepository.Add(scheduleParticipants);

        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddAuditScheduleResponseDTO(gid, rowsAffected > 0, rowsAffected > 0 ? "Audit schedule created Successfully!" : "Error while creating Audit schedule !");


        throw new NotImplementedException();
    }
}

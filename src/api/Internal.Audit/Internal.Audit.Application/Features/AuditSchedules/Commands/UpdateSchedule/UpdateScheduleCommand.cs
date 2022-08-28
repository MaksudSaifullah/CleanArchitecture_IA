using Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;

public class UpdateScheduleCommand:IRequest<UpdateScheduleResponseDTO>
{
    public Guid Id { get; set; }
    public Guid AuditCreationId { get; set; }
    public DateTime ScheduleStartDate { get; set; }
    public DateTime ScheduleEndDate { get; set; }
    public string? ScheduleId { get; set; }
    public int ScheduleState { get; set; }
    public int ExecutionState { get; set; }
    public List<AuditScheduleParticipantsCommand> AuditScheduleParticipants { get; set; }
    public List<AuditScheduleBranchCommand> AuditScheduleBranch { get; set; }
}

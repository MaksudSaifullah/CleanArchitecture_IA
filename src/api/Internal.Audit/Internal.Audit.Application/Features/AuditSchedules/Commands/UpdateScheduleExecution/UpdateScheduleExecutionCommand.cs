using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateScheduleExecution;

public record UpdateScheduleExecutionCommand(Guid Id,int ScheduleState=-1, int ExecutionState=-1) :IRequest<UpdateScheduleExecutionCommandResponseDTO>;
//{
//    public Guid Id { get; set; }

//    public int ScheduleState { get; set; } = -1;
//    public int ExecutionState { get; set; } = -1;
//}

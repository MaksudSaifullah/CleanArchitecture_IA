using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditSchedules.Commands.AddAuditSchedule;

public class AddAuditScheduleCommand:IRequest<AddAuditScheduleResponseDTO>
{
    public Guid? Id { get; set; }
    public Guid AuditCreationId { get; set; }
    public DateTime ScheduleStartDate { get; set; }    
    public DateTime ScheduleEndDate { get; set; }
    public List<AuditScheduleParticipantsCommand> AuditScheduleParticipants { get; set; }
    public List<AuditScheduleBranchCommand> AuditScheduleBranch { get; set; }

}
public class AuditScheduleParticipantsCommand
{   
    public Guid? AuditScheduleId { get; set; }   
    public Guid UserId { get; set; }    
    public int CommonValueParticipantId { get; set; } 
}

public class AuditScheduleBranchCommand
{   
    public Guid? AuditScheduleId { get; set; }  
    public Guid BranchId { get; set; }  
  
}
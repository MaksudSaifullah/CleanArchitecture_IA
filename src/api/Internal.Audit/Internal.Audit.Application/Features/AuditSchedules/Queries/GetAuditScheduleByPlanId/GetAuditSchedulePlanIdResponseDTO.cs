using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;

public class GetAuditSchedulePlanIdResponseDTO
{
    public Guid AuditPlanId { get; set; }   
    public DateTime ScheduleStartDate { get; set; }   
    public DateTime ScheduleEndDate { get; set; }
    public virtual AuditPlan AuditPlan { get; set; } = null!;
    public virtual ICollection<AuditScheduleParticipantsDTO> AuditScheduleParticipants { get; set; } = null!;
}

public class AuditScheduleParticipantsDTO
{  
    public Guid AuditScheduleId { get; set; } 
    public Guid UserId { get; set; }   
    public int CommonValueParticipantId { get; set; }    
    public virtual User User { get; set; } = null!;   
    public virtual CommonValueAndTypeDTO CommonValueAndTypeParticipant { get; set; } = null!;
}
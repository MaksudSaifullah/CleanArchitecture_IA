using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;

public class GetAuditSchedulePlanIdResponseDTO
{
    public Guid AuditPlanId { get; set; }   
    public DateTime ScheduleStartDate { get; set; }   
    public DateTime ScheduleEndDate { get; set; }
    public virtual AuditCreationDTO AuditCreation { get; set; } = null!;
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

public class AuditCreationDTO 
{

    public Guid AuditTypeId { get; set; }  
    public Guid AuditPlanId { get; set; }   
    public string AuditId { get; set; }  
    public Int32 Year { get; set; }   
    public string AuditName { get; set; }  
    public DateTime AuditPeriodFrom { get; set; }
    public DateTime AuditPeriodTo { get; set; }   
    public virtual AuditTypeDTO AuditType { get; set; } = null!;
  
    //public virtual AuditPlanDTO AuditPlan { get; set; } = null!;
}

public class AuditTypeDTO
{

    public string Name { get; set; } = null!;

}
//public class AuditPlanDTO
//{
//    public Guid RiskAssessmentId { get; set; }   
//    public string PlanCode { get; set; } = null!;   
//    public Guid PlanningYearId { get; set; }  
//    public DateTime AssessmentFrom { get; set; }    
//    public DateTime AssessmentTo { get; set; }   
//    public virtual RiskAssessment RiskAssessment { get; set; } = null!;
//}
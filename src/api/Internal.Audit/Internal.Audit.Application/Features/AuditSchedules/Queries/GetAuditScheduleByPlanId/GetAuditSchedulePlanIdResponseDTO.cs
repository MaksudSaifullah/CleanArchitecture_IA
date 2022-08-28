using Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Application.Features.AuditSchedules.Queries.GetAuditScheduleByPlanId;

public class GetAuditSchedulePlanIdResponseDTO
{
    //public Guid AuditPlanId { get; set; }   
    public Guid Id { get; set; }   
    public DateTime ScheduleStartDate { get; set; }   
    public DateTime ScheduleEndDate { get; set; }
    public string? ScheduleId { get; set; }

    public int ScheduleState { get; set; } = -1;
    public int ExecutionState { get; set; } = -1;
    public virtual AuditCreationDTOs AuditCreation { get; set; } = null!;
    public virtual ICollection<AuditScheduleParticipantsDTOs> AuditScheduleParticipants { get; set; } = null!;
    public virtual ICollection<AuditScheduleBranchs> AuditScheduleBranch { get; set; } = null!;
}

public class AuditScheduleParticipantsDTOs
{  
    public Guid AuditScheduleId { get; set; } 
    public Guid UserId { get; set; }   
    public int CommonValueParticipantId { get; set; }    
    public virtual UserDTOs User { get; set; } = null!;   
  //  public virtual CommonValueAndTypeDTO CommonValueAndTypeParticipant { get; set; } = null!;
}

public class AuditCreationDTOs
{

    public Guid AuditTypeId { get; set; }  
    public Guid AuditPlanId { get; set; }   
    public string AuditId { get; set; }  
    public Int32 Year { get; set; }   
    public string AuditName { get; set; }  
    public DateTime AuditPeriodFrom { get; set; }
    public DateTime AuditPeriodTo { get; set; }
    public string AuditTypeName { get; set; }
    //  public virtual AuditTypeDTOs AuditType { get; set; } = null!;

  //  public virtual AuditPlanDTO AuditPlan { get; set; } = null!;
}

public class AuditTypeDTOs
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


public class UserDTOs
{

   
    public string UserName { get; set; } = null!;  
    public string? FullName { get; set; }   
    public string? ProfileImageUrl { get; set; }  
    public bool IsEnabled { get; set; }   
    public bool IsAccountExpired { get; set; }   
    public bool IsPasswordExpired { get; set; }    
    public bool IsAccountLocked { get; set; }     
    public virtual EmployeeDTOs Employee { get; set; }

}

public class AuditScheduleBranchs
{
   
    public Guid AuditScheduleId { get; set; }
 
    public Guid BranchId { get; set; }

    public string BranchName { get; set; }
    // public virtual BranchDTOs Branch { get; set; } = null!;
}

public class BranchDTOs
{
   
    public Guid CountryId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; }
   
    public string? BranchName { get; set; }
  
}

public class EmployeeDTOs
{
  
    public Guid UserId { get; set; }   
    
    public Guid PhotoId { get; set; } //document foreign key

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }      

}
namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Queries.GetAllByAuditScheduleId;

public class GetAllByAuditScheduledIdResponseDTO
{

    public Guid AuditScheduleId { get; set; }
    public int CommonValueAuditScheduleRiskOwnerTypetId { get; set; }
    public Guid BranchId { get; set; }
    public virtual ICollection<UserConfiguration> User { get; set; } = null!;
   
}
public class UserConfiguration
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
}


using MediatR;

namespace Internal.Audit.Application.Features.AuditScheduleConfigurationsOwner.Commands.AddAuditScheduleConfigurationsOwnerCommand;

public class AddAuditScheduleConfigurationsOwnerCommand:IRequest<AuditScheduleConfiurationsOwnerCommandResponseDTO>
{

    public List<AddAuditScheduleConfigurationsOwnerCommandRaw> Data { get; set; }
}
public class AddAuditScheduleConfigurationsOwnerCommandRaw 
{

    public Guid AuditScheduleId { get; set; }
    public Guid UserId { get; set; }
    public Guid BranchId { get; set; }
    public int CommonValueAuditScheduleRiskOwnerTypetId { get; set; }
}

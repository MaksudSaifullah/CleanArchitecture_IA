using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.AuditConfigMilestones.Commands.AddAuditConfigMilestones;

public record AddAuditConfigMilestoneResponseDTO : BaseResponseDTO
{
    public AddAuditConfigMilestoneResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}


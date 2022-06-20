namespace Internal.Audit.Application.Features.AuditAction.Queries.GetActionList;
public record GetAuditActionListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
}
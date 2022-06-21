namespace Internal.Audit.Application.Features.AuditFeature.Queries.GetFeatureList;
public record GetAuditFeatureListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
}
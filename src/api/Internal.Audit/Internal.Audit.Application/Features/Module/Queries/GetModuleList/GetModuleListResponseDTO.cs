namespace Internal.Audit.Application.Features.Module.Queries.GetModuleList;
public record GetModuleListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
}
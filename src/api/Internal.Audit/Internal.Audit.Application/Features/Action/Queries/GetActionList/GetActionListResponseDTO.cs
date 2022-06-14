namespace Internal.Audit.Application.Features.Action.Queries.GetActionList;
public record GetActionListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
}
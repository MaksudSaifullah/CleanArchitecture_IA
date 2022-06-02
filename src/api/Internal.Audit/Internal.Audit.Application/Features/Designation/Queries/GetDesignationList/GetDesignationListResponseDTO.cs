
namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public record GetDesignationListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

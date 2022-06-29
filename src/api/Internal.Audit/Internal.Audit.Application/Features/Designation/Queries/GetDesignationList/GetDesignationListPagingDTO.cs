
namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public record GetDesignationListPagingDTO
{
    public IEnumerable<GetDesignationListResponseDTO> Items { get; set; } = null!;
    public long TotalCount { get; set; }
}
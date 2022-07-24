using MediatR;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public class GetDesignationListQuery : IRequest<GetDesignationListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; } = null;
}
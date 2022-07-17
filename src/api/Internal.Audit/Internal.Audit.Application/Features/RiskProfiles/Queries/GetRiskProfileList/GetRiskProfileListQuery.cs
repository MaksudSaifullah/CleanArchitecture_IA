using MediatR;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList;
public class GetRiskProfileListQuery : IRequest<RiskProfileListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}

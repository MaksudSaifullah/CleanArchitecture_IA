using MediatR;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList;
public class GetRiskCriteriaListQuery : IRequest<RiskCriteriaListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}

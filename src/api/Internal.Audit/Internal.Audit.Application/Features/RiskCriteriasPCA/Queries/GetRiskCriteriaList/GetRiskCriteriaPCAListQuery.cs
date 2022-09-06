using MediatR;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaList;
public class GetRiskCriteriaPCAListQuery : IRequest<RiskCriteriaPCAListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}

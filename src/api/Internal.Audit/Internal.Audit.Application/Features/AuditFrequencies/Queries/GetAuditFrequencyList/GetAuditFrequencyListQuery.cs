using MediatR;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList;
public class GetAuditFrequencyListQuery : IRequest<AuditFrequencyListPagingDTO>
{
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public dynamic searchTerm { get; set; }
}
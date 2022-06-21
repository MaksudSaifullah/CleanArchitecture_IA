using MediatR;

namespace Internal.Audit.Application.Features.AuditFeature.Queries.GetFeatureList;
public class GetAuditFeatureListQuery : IRequest<List<GetAuditFeatureListResponseDTO>>
{
}
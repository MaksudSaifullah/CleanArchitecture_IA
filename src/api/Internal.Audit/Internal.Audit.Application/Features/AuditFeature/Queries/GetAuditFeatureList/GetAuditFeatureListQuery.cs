using MediatR;

namespace Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
public class GetAuditFeatureListQuery : IRequest<List<GetAuditFeatureListResponseDTO>>
{
}
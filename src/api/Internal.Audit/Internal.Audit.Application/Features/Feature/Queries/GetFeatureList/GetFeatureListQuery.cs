using MediatR;

namespace Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
public class GetFeatureListQuery : IRequest<List<GetFeatureListResponseDTO>>
{
}
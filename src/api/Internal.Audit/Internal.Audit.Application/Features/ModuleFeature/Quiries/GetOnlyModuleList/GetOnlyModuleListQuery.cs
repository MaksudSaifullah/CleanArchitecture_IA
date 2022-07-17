using MediatR;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetOnlyModuleList;

public class GetOnlyModuleListQuery:IRequest<IEnumerable<GetOnlyModuleListResponseDTO>>
{
}

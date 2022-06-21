using MediatR;

namespace Internal.Audit.Application.Features.Module.Queries.GetModuleList;
public class GetActionModuleListQuery : IRequest<List<GetActionModuleListResponseDTO>>
{
}
using MediatR;

namespace Internal.Audit.Application.Features.Module.Queries.GetModuleList;
public class GetModuleListQuery : IRequest<List<GetModuleListResponseDTO>>
{
}
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public class GetDesignationListQuery : IRequest<List<GetDesignationListResponseDTO>>
{
}
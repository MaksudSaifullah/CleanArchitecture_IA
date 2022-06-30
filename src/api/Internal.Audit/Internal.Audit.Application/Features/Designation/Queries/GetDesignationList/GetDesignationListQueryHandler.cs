using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public class GetDesignationListQueryHandler : IRequestHandler<GetDesignationListQuery, GetDesignationListPagingDTO>
{
    private readonly IDesignationQueryRepository _designationRepository;
    private readonly IMapper _mapper;

    public GetDesignationListQueryHandler(IDesignationQueryRepository designationRepository, IMapper mapper)
    {
        _designationRepository = designationRepository;
        _mapper = mapper;
    }

    public async Task<GetDesignationListPagingDTO> Handle(GetDesignationListQuery request, CancellationToken cancellationToken)
    {
        var (count, result) = await _designationRepository.GetAll(request.pageSize, request.pageNumber);
        var designationList = _mapper.Map<List<GetDesignationListResponseDTO>>(result);
        return new GetDesignationListPagingDTO { Items = designationList, TotalCount = count };
    }
}

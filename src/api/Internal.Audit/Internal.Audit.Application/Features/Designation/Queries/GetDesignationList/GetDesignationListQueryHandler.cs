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
        (long, IEnumerable<Domain.Entities.common.Designation>) xx = await _designationRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);
        var designationList = _mapper.Map<List<GetDesignationListResponseDTO>>(xx.Item2);
        return new GetDesignationListPagingDTO { Items = designationList, TotalCount = xx.Item1 };
    }
}

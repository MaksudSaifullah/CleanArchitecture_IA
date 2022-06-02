using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using MediatR;

namespace Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
public class GetDesignationListQueryHandler : IRequestHandler<GetDesignationListQuery, List<GetDesignationListResponseDTO>>
{
    private readonly IDesignationQueryRepository _designationRepository;
    private readonly IMapper _mapper;

    public GetDesignationListQueryHandler(IDesignationQueryRepository designationRepository, IMapper mapper)
    {
        _designationRepository = designationRepository;
        _mapper = mapper;
    }

    public async Task<List<GetDesignationListResponseDTO>> Handle(GetDesignationListQuery request, CancellationToken cancellationToken)
    {
        var designationList = await _designationRepository.GetAll();
        return _mapper.Map<List<GetDesignationListResponseDTO>>(designationList);
    }
}

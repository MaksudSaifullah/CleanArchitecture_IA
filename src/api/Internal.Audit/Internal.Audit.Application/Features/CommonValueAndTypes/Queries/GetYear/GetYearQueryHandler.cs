using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetYear;
public class GetYearQueryHandler : IRequestHandler<GetYearQuery, List<YearDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly IMapper _mapper;

    public GetYearQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<YearDTO>> Handle(GetYearQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndTypes = await _commonValueAndTypesRepository.GetAllYear();
        return _mapper.Map<List<YearDTO>>(commonValueAndTypes);
    }
}

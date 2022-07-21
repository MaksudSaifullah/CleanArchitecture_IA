using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSelectionMethod;
public class GetSampleSelectionMethodQueryHandler : IRequestHandler<GetSampleSelectionMethodQuery, List<SampleSelectionMethodDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypesRepository;
    private readonly IMapper _mapper;

    public GetSampleSelectionMethodQueryHandler(ICommonValueAndTypeQueryRepository commonValueAndTypesRepository, IMapper mapper)
    {
        _commonValueAndTypesRepository = commonValueAndTypesRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<SampleSelectionMethodDTO>> Handle(GetSampleSelectionMethodQuery request, CancellationToken cancellationToken)
    {
        var commonValueAndTypes = await _commonValueAndTypesRepository.GetCommonValueType("SAMPLESELECTIONMETHOD");
        return _mapper.Map< List<SampleSelectionMethodDTO>>(commonValueAndTypes);
    }
}

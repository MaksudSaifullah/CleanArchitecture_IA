using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetSampleSize;

public class GetSizeByFrequencyHandler : IRequestHandler<GetSizeByFrequencyQuery, IEnumerable<SampleSizeDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypeRepository;
    private readonly IMapper _mapper;

    public GetSizeByFrequencyHandler(ICommonValueAndTypeQueryRepository commonValueAndTypeRepository, IMapper mapper)
    {
        _commonValueAndTypeRepository = commonValueAndTypeRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypeRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<IEnumerable<SampleSizeDTO>> Handle(GetSizeByFrequencyQuery request, CancellationToken cancellationToken)
    {
        var sampleSize = await _commonValueAndTypeRepository.GetByControlFrequencyId(request.Id);
        return _mapper.Map<IList<SampleSizeDTO>>(sampleSize);
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetControlFrequency;
public class GetFrequencyByCotrolActivityHandler : IRequestHandler<GetFrequencyByNatureActivityQuery, IEnumerable<ControlFrequencyDTO>>
{
    private readonly ICommonValueAndTypeQueryRepository _commonValueAndTypeRepository;
    private readonly IMapper _mapper;

    public GetFrequencyByCotrolActivityHandler(ICommonValueAndTypeQueryRepository commonValueAndTypeRepository, IMapper mapper)
    {
        _commonValueAndTypeRepository = commonValueAndTypeRepository ?? throw new ArgumentNullException(nameof(commonValueAndTypeRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<IEnumerable<ControlFrequencyDTO>> Handle(GetFrequencyByNatureActivityQuery request, CancellationToken cancellationToken)
    {
        var controlFrequency = await _commonValueAndTypeRepository.GetByControlActivityId(request.Id);
        return _mapper.Map<IList<ControlFrequencyDTO>>(controlFrequency);
    }
}
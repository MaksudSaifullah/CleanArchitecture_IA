using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryByIdDTO>
{
    private readonly ICountryQueryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountryQueryHandler(ICountryQueryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CountryByIdDTO> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetById(request.Id);
        return _mapper.Map<CountryByIdDTO>(country);
    }
}

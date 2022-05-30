using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using MediatR;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountryDTO>>
    {
        private readonly ICountryQueryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryListQueryHandler(ICountryQueryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CountryDTO>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.GetAll();
            return _mapper.Map<List<CountryDTO>>(countries);
        }        
    }
}




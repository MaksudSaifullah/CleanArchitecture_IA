using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using MediatR;

namespace Internal.Audit.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, CountryListPagingDTO>
    {
        private readonly ICountryQueryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetCountryListQueryHandler(ICountryQueryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CountryListPagingDTO> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            (long, IEnumerable<Country>) country = await _countryRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);
            var countryList = _mapper.Map<List<CountryDTO>>(country.Item2);
            return new CountryListPagingDTO { Items = countryList, TotalCount = country.Item1 };
        }
    }
}




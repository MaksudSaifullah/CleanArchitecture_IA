using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Countries;
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
            var (count, result) = await _countryRepository.GetAll(request.pageSize, request.pageNumber);

            var countryList = _mapper.Map<IEnumerable<CountryDTO>>(result).ToList();

            return new CountryListPagingDTO { CountryList = countryList, TotalCount = count };
        }
    }
}




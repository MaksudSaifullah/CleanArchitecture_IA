using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryById;
using Internal.Audit.Application.Features.Countries.Queries.GetCountryList;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Internal.Audit.Test.Systems.Country.Queries
{
    public class GetCountryListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICountryQueryRepository> _mockRepo, _mockRepoById;
        private readonly GetCountryListQuery _countryListRequest;
        private readonly GetCountryQuery _countryRequest;

        public GetCountryListRequestHandlerTests()
        {
            CountryMockData.AddCountryStatic();
            _mockRepo = MockCountryRepository.GetAllCountries();
            _mockRepoById = MockCountryRepository.GetAllCountriesByID();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _countryListRequest = new GetCountryListQuery
            {
                pageSize = 10,
                pageNumber = 1,
                searchTerm = null
            };

            _mapper = mapperConfig.CreateMapper();

            _countryRequest = new GetCountryQuery(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }


        [Fact]
        public async Task GetCountryList()
        {
            ///arrange
            var handler = new GetCountryListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_countryListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<CountryListPagingDTO>();

            result.Items.Count().ShouldBe(4);
        }

        [Fact]
        public async Task GetCountryByID()
        {
            ///arrange
            var handler = new GetCountryQueryHandler(_mockRepoById.Object, _mapper);

            ///act
            var result = await handler.Handle(_countryRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<CountryByIdDTO>();

            result.Id.ShouldBe(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }
    }
}

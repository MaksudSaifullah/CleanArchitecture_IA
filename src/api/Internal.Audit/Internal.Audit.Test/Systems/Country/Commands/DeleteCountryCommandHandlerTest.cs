using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Features.Countries.Commands.DeleteCountry;
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

namespace Internal.Audit.Test.Systems.Country.Commands
{
    public class DeleteCountryCommandHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mock<ICountryCommandRepository> _mockRepo;
       // private readonly Mock<ICountryQueryRepository> _mockRepoList;
        private readonly IMapper _mapper;
        private readonly DeleteCountryCommand _countryDeleteRequest;

        public DeleteCountryCommandHandlerTest()
        {
            CountryMockData.AddCountryStatic();
            //_mockRepoList = MockCountryRepository.GetAllCountriesByID();
            //_mockRepo = MockCountryRepository.CreateCountries();
            CountryMockData.updateAddCountryStatic();

           // _mockRepoList = MockCountryRepository.DeleteCountriesByID();
            _mockRepo = MockCountryRepository.DeleteUpdateCountries();

            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

             _countryDeleteRequest = new DeleteCountryCommand ( new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }

        [Fact]
        public async Task DeleteCountry()
        {
            ///arrange
            var handler = new DeleteCountryCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_countryDeleteRequest, CancellationToken.None);

            var country = CountryMockData.updateCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();


            if (country != null)
            {
                country.IsDeleted = true;
            }
            
            ///assert
            result.ShouldBeOfType<DeleteCountryResponseDTO>();
        }
    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Features.Countries.Commands.AddCountry;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Internal.Audit.Domain.Entities.common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Internal.Audit.Test.Systems.Country.Commands
{
    public class CreateCountryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICountryCommandRepository> _mockRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AddCountryCommand _countryResponseDTO;

        public CreateCountryCommandHandlerTest()
        {
            _mockRepo = MockCountryRepository.CreateCountries();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            _countryResponseDTO = new AddCountryCommand
            {
                Name = "SreeMangal",
                Code = "SM",
                Remarks = "SUDDEN PLAN"
            };

        }

        [Fact]
        public async Task CreateCountry()
        {
            ///arrange
            var handler = new AddCountryCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_countryResponseDTO, CancellationToken.None);

            CountryMockData.ResetCountryStatic();
            CountryMockData.AddCountryStatic();
            CountryMockData.countryList.Add(new Internal.Audit.Domain.Entities.Country
            {
                Name = "SreeMangal",
                Code = "SM",
                Remarks = "SUDDEN PLAN"
            });

            ///assert
            result.ShouldBeOfType<AddCountryResponseDTO>();

            CountryMockData.countryList.Count().ShouldBe(4);
        }

    }
}

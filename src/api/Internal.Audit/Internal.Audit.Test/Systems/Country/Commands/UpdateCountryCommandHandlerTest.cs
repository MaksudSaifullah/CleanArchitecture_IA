using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Features.Countries.Commands.UpdateCountry;
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
    public class UpdateCountryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly Mock<ICountryCommandRepository> _mockRepo;
        private readonly UpdateCountryCommand _countryUpdateRequest;

        public UpdateCountryCommandHandlerTest()
        {
            CountryMockData.AddCountryStatic();
            CountryMockData.updateAddCountryStatic();

            _mockRepo = MockCountryRepository.UpdateCountries();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
                
            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            _countryUpdateRequest = new UpdateCountryCommand
            {
                Id = new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"),
                Name = "Rowanda",
                Code = "005",
                Remarks = ""
            };
        }


        [Fact]
        public async Task UpdateCountry()
        {
            ///arrange
            var handler = new UpdateCountryCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_countryUpdateRequest, CancellationToken.None);

            var country = CountryMockData.updateCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();


            if (country != null)
            {
                country.Name = "ASA International";
            }

            ///assert
            result.ShouldBeOfType<UpdateCountryResponseDTO>();

        }
    }
}

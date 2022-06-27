using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Test.MockDatas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internal.Audit.Test.MockRepositories
{
    public class MockCountryRepository
    {
        public MockCountryRepository()
        {
            CountryMockData.AddCountryStatic();
        }

        public static Mock<ICountryQueryRepository> GetAllCountries()
        {
            var countries = CountryMockData.GetCountriesData();
            var mockRepo = new Mock<ICountryQueryRepository>();
            mockRepo.Setup(x => x.GetAll(10, 1)).ReturnsAsync((1, countries));
            return mockRepo;
        }

        public static Mock<ICountryQueryRepository> GetAllCountriesByID()
        {
            var country = CountryMockData.GetCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<ICountryQueryRepository>();
            mockRepo.Setup(x => x.GetById(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(country);
            return mockRepo;
        }

/*        public static Mock<ICountryQueryRepository> DeleteCountriesByID()
        {
            var country = CountryMockData.deleteCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<ICountryQueryRepository>();
            mockRepo.Setup(x => x.GetById(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(country);
            return mockRepo;
        }
        public static Mock<ICountryQueryRepository> UpdateCountriesByID()
        {
            var country = CountryMockData.updateCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<ICountryQueryRepository>();
            mockRepo.Setup(x => x.GetById(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(country);
            return mockRepo;
        }*/

        public static Mock<ICountryCommandRepository> CreateCountries()
        {
            var mockRepoCreate = new Mock<ICountryCommandRepository>();
            mockRepoCreate.Setup(r => r.Add(It.IsAny<Country>())).ReturnsAsync((Country country) =>
            {
                CountryMockData.countryList.Add(new Country { });
                return country;
            });
            return mockRepoCreate;
        }

        public static Mock<ICountryCommandRepository> DeleteUpdateCountries()
        {
            var country = CountryMockData.GetCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<ICountryCommandRepository>();
            mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(country);
            return mockRepo;
        }
        public static Mock<ICountryCommandRepository> UpdateCountries()
        {
            var country = CountryMockData.GetCountriesData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<ICountryCommandRepository>();
            mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(country);
            mockRepo.Setup(x => x.Update(country)).ReturnsAsync(country);
            return mockRepo;
        }

    }
}

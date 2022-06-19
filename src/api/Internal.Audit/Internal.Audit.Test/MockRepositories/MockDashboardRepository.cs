using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Test.MockDatas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockRepositories
{
    public class MockDashboardRepository
    {
        public MockDashboardRepository()
        {
            DashboardMockData.AddDashboardStatic();
        }

        public static Mock<IDashboardQueryRepository> GetAllDashboards()
        {
            var dashboards = DashboardMockData.GetDashBoardsData();
            var mockRepo = new Mock<IDashboardQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(dashboards);
            return mockRepo;
        }

        public static Mock<IDashboardQueryRepository> GetAllDashboardsByID()
        {
            var dashboard = DashboardMockData.GetDashBoardsData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<IDashboardQueryRepository>();
            mockRepo.Setup(x => x.GetById(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(dashboard);
            return mockRepo;
        }

       /* public static Mock<IDashboardCommandRepository> CreateDashboards()
        { 
            var dashboard = DashboardMockData.GetDashBoardsData();
            var mockRepoCreate = new Mock<IDashboardCommandRepository>();
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
        }*/


    }
}

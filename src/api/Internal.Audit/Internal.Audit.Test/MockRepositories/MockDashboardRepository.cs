using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Domain.Entities.Common;
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

        public static Mock<IDashboardCommandRepository> CreateDashboards()
        {
            var dashboard = DashboardMockData.GetDashBoardsData();
            var mockRepoCreate = new Mock<IDashboardCommandRepository>();
            mockRepoCreate.Setup(r => r.Add(It.IsAny<DashBoardBase>())).ReturnsAsync((DashBoardBase dashboard) =>
            {
                DashboardMockData.dashboardList.Add(new DashBoardBase { });
                return dashboard;
            });
            return mockRepoCreate;
        }

        public static Mock<IDashboardCommandRepository> DeleteUpdateDashboards()
        {
            var dashboard = DashboardMockData.GetDashBoardsData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<IDashboardCommandRepository>();
            mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(dashboard);
            return mockRepo;
        }
        public static Mock<IDashboardCommandRepository> UpdateDashboards()
        {
            var dashboard = DashboardMockData.GetDashBoardsData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
            var mockRepo = new Mock<IDashboardCommandRepository>();
            mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(dashboard);
            mockRepo.Setup(x => x.Update(dashboard)).ReturnsAsync(dashboard);
            return mockRepo;
        }


    }
}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardById;
using Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardList;
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

namespace Internal.Audit.Test.Systems.Dashboard.Queries
{
    public class GetDashboardListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDashboardQueryRepository> _mockRepo, _mockRepoById;
        private readonly GetDashboardListQuery _dashboardListRequest;
        private readonly GetDashboardQuery _dashboardRequest;

        public GetDashboardListRequestHandlerTests()
        {
            DashboardMockData.AddDashboardStatic();
            _mockRepo = MockDashboardRepository.GetAllDashboards();
            _mockRepoById = MockDashboardRepository.GetAllDashboardsByID();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _dashboardRequest = new GetDashboardQuery(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }


        [Fact]
        public async Task GetDashboardList()
        {
            ///arrange
            var handler = new GetDashboardListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_dashboardListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<DashboardDTO>>();

            result.Count().ShouldBe(4);
        }

        [Fact]
        public async Task GetDashboardByID()
        {
            ///arrange
            var handler = new GetDashboardQueryHandler(_mockRepoById.Object, _mapper);

            ///act
            var result = await handler.Handle(_dashboardRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<DashboardByIdDTO>();

            result.Id.ShouldBe(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }
    }
}

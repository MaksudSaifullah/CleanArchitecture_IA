using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Application.Features.Dashboards.Commands.AddDashboard;
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

namespace Internal.Audit.Test.Systems.Dashboard.Commands
{
    public class CreateDashboardCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IDashboardCommandRepository> _mockRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AddDashboardCommand _dashboardResponseDTO;

        public CreateDashboardCommandHandlerTest()
        {
            _mockRepo = MockDashboardRepository.CreateDashboards();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            _dashboardResponseDTO = new AddDashboardCommand
            {
                Name = "SreeMangal",
                Status = true
            };

        }

        [Fact]
        public async Task CreateDashboard()
        {
            ///arrange
            var handler = new AddDashboardCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_dashboardResponseDTO, CancellationToken.None);

            DashboardMockData.ResetDashboardStatic();
            DashboardMockData.AddDashboardStatic();
            DashboardMockData.dashboardList.Add(new Internal.Audit.Domain.Entities.Common.DashBoardBase
            {
                Name = "Personal",
                Status = true
            });

            ///assert
            result.ShouldBeOfType<AddDashboardResponseDTO>();

            DashboardMockData.dashboardList.Count().ShouldBe(4);
        }

    }
}

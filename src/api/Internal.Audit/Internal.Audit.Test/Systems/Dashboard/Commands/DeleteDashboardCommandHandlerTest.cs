using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Application.Features.Dashboards.Commands.DeleteDashboard;
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
    public class DeleteDashboardCommandHandlerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mock<IDashboardCommandRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly DeleteDashboardCommand _dashboardDeleteRequest;

        public DeleteDashboardCommandHandlerTest()
        {
            DashboardMockData.AddDashboardStatic();
            DashboardMockData.updateAddDashboardStatic();

            _mockRepo = MockDashboardRepository.DeleteUpdateDashboards();

            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _dashboardDeleteRequest = new DeleteDashboardCommand(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
        }

        [Fact]
        public async Task DeleteDashboard()
        {
            ///arrange
            var handler = new DeleteDashboardCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_dashboardDeleteRequest, CancellationToken.None);

            var dashboard = DashboardMockData.updateDashBoardsData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();


            if (dashboard != null)
            {
                dashboard.IsDeleted = true;
            }

            ///assert
            result.ShouldBeOfType<DeleteDashboardResponseDTO>();
        }
    }
}

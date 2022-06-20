using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Application.Features.Dashboards.Commands.UpdateDashboard;
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
    public class UpdateDashboardCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly Mock<IDashboardCommandRepository> _mockRepo;
        private readonly UpdateDashboardCommand _dashboardUpdateRequest;

        public UpdateDashboardCommandHandlerTest()
        {
            DashboardMockData.AddDashboardStatic();
            DashboardMockData.updateAddDashboardStatic();

            _mockRepo = MockDashboardRepository.UpdateDashboards();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            var mockUoW = new Mock<IUnitOfWork>();
            _unitOfWork = mockUoW.Object;

            _dashboardUpdateRequest = new UpdateDashboardCommand
            {
                Id = new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"),
                Name = "Personal",
                Status = true
            };
        }


        [Fact]
        public async Task UpdateDashboard()
        {
            ///arrange
            var handler = new UpdateDashboardCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);

            ///act
            var result = await handler.Handle(_dashboardUpdateRequest, CancellationToken.None);

            var dashboard = DashboardMockData.updateDashBoardsData().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();


            if (dashboard != null)
            {
                dashboard.Name = "ASA International";
            }

            ///assert
            result.ShouldBeOfType<UpdateDashboardResponseDTO>();

        }
    }
}

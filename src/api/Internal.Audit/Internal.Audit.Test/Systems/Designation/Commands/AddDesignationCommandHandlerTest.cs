using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Application.Features.Designation.Commands.AddDesignation;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Internal.Audit.Test.Systems.Designation.Commands;
public class AddDesignationCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IDesignationCommandRepository> _mockRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AddDesignationCommand _designationCommandDTO;

    public AddDesignationCommandHandlerTest()
    {
        _mockRepo = MockDesignationRepository.AddDesignation();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        var mockUoW = new Mock<IUnitOfWork>();
        _unitOfWork = mockUoW.Object;

        _designationCommandDTO = new AddDesignationCommand
        {
            Name = "SQA",
            Description = "Software Quality Assuarance"
        };

    }

    [Fact]
    public async Task AddDesignation()
    {
        ///arrange
        var handler = new AddDesignationCommandHandler(_mockRepo.Object, _mapper, _unitOfWork);
        ///act
        var result = await handler.Handle(_designationCommandDTO, CancellationToken.None);

        DesignationMockData.ResetDesignationStatic();
        DesignationMockData.AddDesignationStatic();
        DesignationMockData.designationList.Add(new Internal.Audit.Domain.Entities.common.Designation
        {
            Name = "Personal",
            Description = ""
        });

        ///assert
        //result.ShouldBeOfType<AddDesignationCommand>();

//        DashboardMockData.dashboardList.Count().ShouldBe(4);
    }
}
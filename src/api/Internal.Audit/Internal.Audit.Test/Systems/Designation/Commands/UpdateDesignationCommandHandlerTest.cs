using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Application.Features.Designation.Commands.UpdateDesignation;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Internal.Audit.Test.Systems.Designation.Commands;
public class UpdateDesignationCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    private readonly Mock<IDesignationCommandRepository> _mockRepo;
    private readonly UpdateDesignationCommand _designationUpdateRequest;
    public UpdateDesignationCommandHandlerTest()
    {
        DesignationMockData.AddDesignationStatic();
        DesignationMockData.updateDesignationStatic();

        _mockRepo = MockDesignationRepository.UpdateDesignation();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        var mockUoW = new Mock<IUnitOfWork>();
        _unitOfWork = mockUoW.Object;

        _designationUpdateRequest = new UpdateDesignationCommand
        {
            Id = new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"),
            Name = "Rowanda",
            Description = "005"
        };
    }

    [Fact]
    public async Task UpdateDesignation()
    {
        ///arrange
        var handler = new UpdateDesignationCommandHandler(_unitOfWork, _mockRepo.Object, _mapper );
        ///act
        var result = await handler.Handle(_designationUpdateRequest, CancellationToken.None);
        var designation = DesignationMockData.updateDesignation().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();

        if (designation != null)
        {
            designation.Name = "ASA International";
        }
        ///assert
        result.ShouldBeOfType<UpdateDesignationResponseDTO>();

    }
}
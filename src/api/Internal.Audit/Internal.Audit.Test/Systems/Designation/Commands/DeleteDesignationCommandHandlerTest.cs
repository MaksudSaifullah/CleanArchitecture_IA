using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Application.Features.Designation.Commands.DeleteDesignation;
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
public class DeleteDesignationCommandHandlerTest
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mock<IDesignationCommandRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly DeleteDesignationCommand _designationDeleteRequest;

    public DeleteDesignationCommandHandlerTest()
    {
        DesignationMockData.AddDesignationStatic();
        DesignationMockData.updateDesignationStatic();

        _mockRepo = MockDesignationRepository.DeleteDesignation();

        var mockUoW = new Mock<IUnitOfWork>();
        _unitOfWork = mockUoW.Object;

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        _designationDeleteRequest = new DeleteDesignationCommand(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"));
    }
    [Fact]
    public async Task DeleteDesignation()
    {
        ///arrange
        var handler = new DeleteDesignationCommandHandler(_unitOfWork, _mockRepo.Object, _mapper);
        ///act
        var result = await handler.Handle(_designationDeleteRequest, CancellationToken.None);
        var designation = DesignationMockData.updateDesignation().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
        if (designation != null)
        {
            designation.IsDeleted = true;
            designation.IsActive = false;
        }
        ///assert
        result.ShouldBeOfType<DeleteDesignationResponseDTO>();
    }
}
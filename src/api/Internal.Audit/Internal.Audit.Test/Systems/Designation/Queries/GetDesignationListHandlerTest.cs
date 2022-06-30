using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Application.Features.Designation.Queries.GetDesignationList;
using Internal.Audit.Application.Mappings;
using Internal.Audit.Test.MockDatas;
using Internal.Audit.Test.MockRepositories;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Internal.Audit.Test.Systems.Designation.Queries;
public class GetDesignationListHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IDesignationQueryRepository> _mockRepo;
    private readonly GetDesignationListQuery _designationListQuery;
    public GetDesignationListHandlerTest()
    {
        DesignationMockData.AddDesignationStatic();
        _mockRepo = MockDesignationRepository.GetAllDesignations();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _designationListQuery = new GetDesignationListQuery
        {
            pageSize = 10,
            pageNumber = 1,
            searchTerm = null
        };

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetDesignationList()
    {
        ///arrange
        var handler = new GetDesignationListQueryHandler(_mockRepo.Object, _mapper);
        ///act
        var result = await handler.Handle(_designationListQuery, CancellationToken.None);
        ///assert
        result.ShouldBeOfType<GetDesignationListPagingDTO>();

        result.Items.Count().ShouldBe(3);
    }
}
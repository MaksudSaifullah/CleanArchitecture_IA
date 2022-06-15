using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Actions;
using Internal.Audit.Application.Features.Action.Queries.GetActionList;
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

namespace Internal.Audit.Test.Systems.Action.Queries
{
    public class GetActionListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IActionQueryRepository> _mockRepo;
        private readonly GetActionListQuery _actionListRequest;
        // private readonly GetCountryQuery _countryRequest;

        public GetActionListRequestHandlerTests()
        {
            ActionMockData.AddActionStatic();
            _mockRepo = MockActionRepository.GetAllActions();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }


        [Fact]
        public async Task GetActionList()
        {
            ///arrange 
            var handler = new GetActionListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_actionListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<GetActionListResponseDTO>>();

            result.Count().ShouldBe(3);
        }
    }

      
}

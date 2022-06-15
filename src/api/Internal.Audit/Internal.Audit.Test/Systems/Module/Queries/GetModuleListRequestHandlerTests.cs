using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Modules;
using Internal.Audit.Application.Features.Module.Queries.GetModuleList;
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

namespace Internal.Audit.Test.Systems.Module.Queries
{
    public class GetModuleListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IModuleQueryRepository> _mockRepo;
        private readonly GetModuleListQuery _moduleListRequest;

        public GetModuleListRequestHandlerTests()
        {
            ModuleMockData.AddModuleStatic();
            _mockRepo = MockModuleRepository.GetAllModules();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }


        [Fact]
        public async Task GetModuleList()
        {
            ///arrange 
            var handler = new GetModuleListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_moduleListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<GetModuleListResponseDTO>>();

            result.Count().ShouldBe(3);
        }
    }


}

using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Features;
using Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
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

namespace Internal.Audit.Test.Systems.Feature.Queries
{
    public class GetFeatureListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IFeatureQueryRepository> _mockRepo;
        private readonly GetFeatureListQuery _featureListRequest;

        public GetFeatureListRequestHandlerTests()
        {
            FeatureMockData.AddFeatureStatic();
            _mockRepo = MockFeatureRepository.GetAllFeatures();


            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }


        [Fact]
        public async Task GetFeatureList()
        {
            ///arrange 
            var handler = new GetFeatureListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_featureListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<GetFeatureListResponseDTO>>();

            result.Count().ShouldBe(3);
        }
    }


}

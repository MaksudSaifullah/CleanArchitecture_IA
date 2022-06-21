using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.AuditFeatures;
using Internal.Audit.Application.Features.AuditFeature.Queries.GetFeatureList;
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
    public class GetAuditFeatureListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAuditFeatureQueryRepository> _mockRepo;
        private readonly GetAuditFeatureListQuery _featureListRequest;

        public GetAuditFeatureListRequestHandlerTests()
        {
            AuditFeatureMockData.AddFeatureStatic();
            _mockRepo = MockAuditFeatureRepository.GetAllFeatures();


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
            var handler = new GetAuditFeatureListQueryHandler(_mockRepo.Object, _mapper);

            ///act
            var result = await handler.Handle(_featureListRequest, CancellationToken.None);

            ///assert
            result.ShouldBeOfType<List<GetAuditFeatureListResponseDTO>>();

            result.Count().ShouldBe(3);
        }
    }


}

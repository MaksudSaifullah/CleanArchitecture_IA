using Internal.Audit.Application.Contracts.Persistent.Features;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Test.MockDatas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Test.MockRepositories
{
    public class MockFeatureRepository
    {
        public MockFeatureRepository()
        {
            FeatureMockData.AddFeatureStatic();
        }

        public static Mock<IFeatureQueryRepository> GetAllFeatures()
        {
            var features = FeatureMockData.GetFeaturesData();
            var mockRepo = new Mock<IFeatureQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(features);
            return mockRepo;
        }


    }
}

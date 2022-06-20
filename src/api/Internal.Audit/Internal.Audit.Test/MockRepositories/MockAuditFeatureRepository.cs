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
    public class MockAuditFeatureRepository
    {
        public MockAuditFeatureRepository()
        {
            AuditFeatureMockData.AddFeatureStatic();
        }

        public static Mock<IAuditFeatureQueryRepository> GetAllFeatures()
        {
            var features = AuditFeatureMockData.GetFeaturesData();
            var mockRepo = new Mock<IAuditFeatureQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(features);
            return mockRepo;
        }


    }
}

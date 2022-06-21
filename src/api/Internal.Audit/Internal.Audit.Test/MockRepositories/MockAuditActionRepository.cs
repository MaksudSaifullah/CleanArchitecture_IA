using Internal.Audit.Application.Contracts.Persistent.Actions;
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
    public class MockAuditActionRepository
    {
        public MockAuditActionRepository()
        {
            AuditActionMockData.AddActionStatic();
        }

        public static Mock<IAuditActionQueryRepository> GetAllActions()
        {
            var actions = AuditActionMockData.GetActionsData();
            var mockRepo = new Mock<IAuditActionQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(actions);
            return mockRepo;
        }


    }
}

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
    public class MockActionRepository
    {
        public MockActionRepository()
        {
            ActionMockData.AddActionStatic();
        }

        public static Mock<IActionQueryRepository> GetAllActions()
        {
            var actions = ActionMockData.GetActionsData();
            var mockRepo = new Mock<IActionQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(actions);
            return mockRepo;
        }


    }
}

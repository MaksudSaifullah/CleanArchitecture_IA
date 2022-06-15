using Internal.Audit.Application.Contracts.Persistent.Modules;
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
    public class MockModuleRepository
    {
        public MockModuleRepository()
        {
            ModuleMockData.AddModuleStatic();
        }

        public static Mock<IModuleQueryRepository> GetAllModules()
        {
            var modules = ModuleMockData.GetModulesData();
            var mockRepo = new Mock<IModuleQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(modules);
            return mockRepo;
        }


    }
}


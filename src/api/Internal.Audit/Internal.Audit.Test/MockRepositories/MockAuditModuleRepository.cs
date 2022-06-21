using Internal.Audit.Application.Contracts.Persistent.AuditModules;
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
    public class MockAuditModuleRepository
    {
        public MockAuditModuleRepository()
        {
            AuditModuleMockData.AddModuleStatic();
        }

        public static Mock<IAuditModuleQueryRepository> GetAllModules()
        {
            var modules = AuditModuleMockData.GetModulesData();
            var mockRepo = new Mock<IAuditModuleQueryRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(modules);
            return mockRepo;
        }


    }
}


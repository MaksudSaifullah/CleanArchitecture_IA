using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Test.MockDatas;
using Moq;
using System;
using System.Linq;

namespace Internal.Audit.Test.MockRepositories;
public class MockDesignationRepository
{
    public MockDesignationRepository()
    {
        DesignationMockData.AddDesignationStatic();
    }

    public static Mock<IDesignationQueryRepository> GetAllDesignations()
    {
        var designations = DesignationMockData.GetDesignationList();
        var mockRepo = new Mock<IDesignationQueryRepository>();
        mockRepo.Setup(x => x.GetAll()).ReturnsAsync(designations);
        return mockRepo;
    }
    public static Mock<IDesignationCommandRepository> AddDesignation()
    {
        var mockCommandRepo = new Mock<IDesignationCommandRepository>();
        mockCommandRepo.Setup(r => r.Add(It.IsAny<Designation>())).ReturnsAsync((Designation designation) =>
        {
            DesignationMockData.designationList.Add(new Designation { });
            return designation;
        });
        return mockCommandRepo;
    }
    public static Mock<IDesignationCommandRepository> DeleteDesignation()
    {
        var designation = DesignationMockData.GetDesignationList().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
        var mockRepo = new Mock<IDesignationCommandRepository>();
        mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(designation);
        return mockRepo;
    }

    public static Mock<IDesignationCommandRepository> UpdateDesignation()
    {
        var designation = DesignationMockData.GetDesignationList().Where(x => x.Id == new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4")).FirstOrDefault();
        var mockRepo = new Mock<IDesignationCommandRepository>();
        mockRepo.Setup(x => x.Get(new Guid("791D35FF-9EA2-4C7B-AA3A-840F50DC59C4"))).ReturnsAsync(designation);
        mockRepo.Setup(x => x.Update(designation)).ReturnsAsync(designation);
        return mockRepo;
    }
}
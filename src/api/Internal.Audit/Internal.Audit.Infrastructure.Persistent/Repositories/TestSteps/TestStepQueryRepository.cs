
using Internal.Audit.Application.Contracts.Persistent.TestSteps;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.TestSteps;

public class TestStepQueryRepository : QueryRepositoryBase<CompositeTestStep>, ITestStepQueryRepository
{
    public TestStepQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeTestStep>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetTestStepListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };

        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeTestStep> GetById(Guid id)
    {
        var query = @"SELECT
	                     TestStep.[Id]
	                    ,Questionnaire.Id AS QuestionnaireId
	                    ,TopicHead.Id AS TopicHeadId
	                    ,Country.Id AS CountryId
	                    ,TestStep.TestStepDetails
	                    ,TestStep.EffectiveFrom
	                    ,TestStep.EffectiveTo
								
                    FROM [BranchAudit].[TestStep]
	                    INNER JOIN BranchAudit.Questionnaire on TestStep.QuestionnaireId = Questionnaire.Id
	                    INNER JOIN BranchAudit.TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
	                    INNER JOIN common.Country on Country.Id = TopicHead.CountryId
	                    WHERE TestStep.IsDeleted = 0 AND TestStep.Id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
}



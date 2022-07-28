using Internal.Audit.Application.Contracts.Persistent.Questionnnaires;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Questionnaires;
public class QuestionnaireQueryRepository : QueryRepositoryBase<CompositeQuestionnaire>, IQuestionnaireQueryRepository
{
    public QuestionnaireQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeQuestionnaire>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetQuestionnaireListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };


        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeQuestionnaire> GetById(Guid id)
    {
        var query = @"SELECT 
                    Questionnaire.Id, 
                    TopicHead.Id AS TopicHeadId,
                    Country.Id AS CountryId,
                    Questionnaire.Question,
                    Questionnaire.EffectiveFrom,
                    Questionnaire.EffectiveTo,
                    Questionnaire.IsActive
                    FROM BranchAudit.Questionnaire as Questionnaire
                    INNER JOIN BranchAudit.TopicHead as TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
                    INNER JOIN common.Country as Country on Country.Id = TopicHead.CountryId
                    WHERE Questionnaire.IsDeleted = 0 AND Questionnaire.Id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}


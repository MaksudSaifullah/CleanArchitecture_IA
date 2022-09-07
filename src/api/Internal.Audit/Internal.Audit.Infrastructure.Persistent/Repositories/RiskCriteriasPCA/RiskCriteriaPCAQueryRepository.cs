
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.CompositeEntities.ProcessAndControlAudit;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskCriteriasPCA
{
    public class RiskCriteriaPCAQueryRepository : QueryRepositoryBase<CompositeRiskCriteriaPCA>, IRiskCriteriaPCAQueryRepository
    {
        public RiskCriteriaPCAQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<(long, IEnumerable<CompositeRiskCriteriaPCA>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
        {
            string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
            if (!string.IsNullOrWhiteSpace(searchTermConverted))
            {
                searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
            }

            var query = "EXEC [dbo].[GetRiskCriteriaPCAListProcedure] @pageSize,@pageNumber,@searchTerm";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };

            return await GetWithPagingInfo(query, parameters, false);
        }
        public async Task<CompositeRiskCriteriaPCA> GetById(Guid id)
        {
            var query = @"SELECT rc.[Id]
                        ,cntr.Id AS [CountryId]
                        ,cntr.Name AS [CountryName]
	                    ,rc.[Name]
		                ,rc.[Weight]
                        ,rc.[EffectiveFrom]
                        ,rc.[EffectiveTo]
                        ,rc.[Description]
                        FROM [ProcessAndControlAudit].[RiskCriteria] as rc
	                    INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId
                        WHERE  rc.[Id] = @id  AND rc.IsDeleted = 0 ";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

    }
}

using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskCriterias
{
    public class RiskCriteriaQueryRepository : QueryRepositoryBase<CompositeRiskCriteria>, IRiskCriteriaQueryRepository
    {
        public RiskCriteriaQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<(long, IEnumerable<CompositeRiskCriteria>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
        {
            string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
            if (!string.IsNullOrWhiteSpace(searchTermConverted))
            {
                searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
            }

            var query = "EXEC [dbo].[GetRiskCriteriaListProcedure] @pageSize,@pageNumber,@searchTerm";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };

            return await GetWithPagingInfo(query, parameters, false);
        }
        public async Task<CompositeRiskCriteria> GetById(Guid id)
        {
            var query = @"SELECT rc.[Id]
                        ,cntr.Id AS CountryId
	                    ,cvtct.Id AS RiskCriteriaTypeId
		                ,rc.[MinimumValue]
		                ,rc.[MaximumValue]
	                    ,cvtrt.Id AS RatingTypeId
		                ,rc.[Score]
                        ,rc.[EffectiveFrom]
                        ,rc.[EffectiveTo]
                        ,rc.[Description]
                        ,rc.[CreatedBy]
                        ,rc.[CreatedOn]		
                         FROM[BranchAudit].[RiskCriteria] as rc
	                INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId  
	                INNER JOIN [config].[CommonValueAndType] as cvtct on cvtct.Id = rc.RiskCriteriaTypeId      
                    INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rc.RatingTypeId
                    WHERE  rc.[Id] = @id  AND rc.IsDeleted = 0 ";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

    }
}

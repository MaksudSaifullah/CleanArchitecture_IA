using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskProfiles;
public class RiskProfileQueryRepository : QueryRepositoryBase<CompositeRiskProfile>, IRiskProfileQueryRepository
{
    public RiskProfileQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeRiskProfile>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetRiskProfileListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };


        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeRiskProfile> GetById(Guid id)
    {
        var query = @"SELECT rp.[Id]
	                ,cvtlt.Id AS LikelihoodTypeId
	                ,cvtit.Id AS ImpactTypeId
	                ,cvtrt.Id AS RatingTypeId
                    ,rp.[EffectiveFrom]
                    ,rp.[EffectiveTo]
                    ,rp.[Description]
                    ,rp.[CreatedBy]
                    ,rp.[CreatedOn]
                    ,rp.[IsActive]
                FROM [common].[RiskProfile] as rp
                INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                WHERE  rp.[Id] = @id AND rp.IsActive = 1 AND rp.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}

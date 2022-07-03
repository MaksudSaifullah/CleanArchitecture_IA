using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskProfiles
{
    public class RiskProfileQueryRepository : QueryRepositoryBase<RiskProfile>, IRiskProfileQueryRepository
    {
        public RiskProfileQueryRepository(string _connectionString) : base(_connectionString)
        {
        }

        public async Task<(long, IEnumerable<RiskProfile>)> GetAll(int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetRiskProfileListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            //return await Get(query);
            return await GetWithPagingInfo(query, parameters, false);
        }
        public async Task<RiskProfile> GetById(Guid id)
        {
            var query = @"SELECT rp.[Id]
	                    ,cvtlt.Text AS LikelihoodType
	                    ,cvtit.Text AS ImpactType
	                    ,cvtit.Text AS RatingType
                        ,rp.[EffectiveFrom]
                        ,rp.[EffectiveTo]
                        ,rp.[Description]
                        ,rp.[CreatedBy]
                        ,rp.[CreatedOn]
                    FROM [common].[RiskProfile] as rp
                    INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                    INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                    INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                    WHERE  Id = @id AND rp.IsActive = 1 AND rp.IsDeleted = 0 ";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

    }
}

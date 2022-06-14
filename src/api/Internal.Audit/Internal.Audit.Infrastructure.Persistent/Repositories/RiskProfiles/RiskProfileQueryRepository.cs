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
        public async Task<IEnumerable<RiskProfile>> GetAll()
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
                        INNER JOIN [dbo].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                        INNER JOIN [dbo].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                        INNER JOIN [dbo].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                        WHERE rp.IsActive = 1 AND rp.IsDeleted = 0 ";
            return await Get(query);
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
                    INNER JOIN [dbo].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                    INNER JOIN [dbo].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                    INNER JOIN [dbo].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                    WHERE  Id = @id AND rp.IsActive = 1 AND rp.IsDeleted = 0 ";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

    }
}

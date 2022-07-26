using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditFrequencies;

public class AuditFrequencyQueryRepository : QueryRepositoryBase<CompositeAuditFrequency>, IAuditFrequencyQueryRepository
{
    public AuditFrequencyQueryRepository(string _connectionString) : base(_connectionString)
    {

    }

    public async Task<(long, IEnumerable<CompositeAuditFrequency>)> GetAll(int pageSize, int pageNumber)
    {
        var query = "EXEC [dbo].[GetAuditFrequencyListProcedure] @pageSize,@pageNumber";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
        // var (count, result) = await GetWithPagingInfo(query, parameters, false);
        //return await Get(query);
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeAuditFrequency> GetById(Guid id)
    {
        var query = @"SELECT af.[Id]
                        ,cntr.Id AS CountryId
	                    ,cvtas.Id AS AuditScoreId
	                    ,cvtrt.Id AS RatingTypeId
                        ,cvtaf.Id AS AuditFrequencyTypeId
                        ,af.[EffectiveFrom]
                        ,af.[EffectiveTo]
                        ,af.[CreatedBy]
                        ,af.[CreatedOn]		
                         FROM[BranchAudit].[AuditFrequency] as af
                    INNER JOIN [common].[Country] as cntr on cntr.Id = af.CountryId 
	                INNER JOIN [config].[CommonValueAndType] as cvtas on cvtas.Id = af.AuditScoreId      
                    INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = af.RatingTypeId
		            INNER JOIN [config].[CommonValueAndType] as cvtaf on cvtaf.Id = af.AuditFrequencyTypeId
                    WHERE  af.[Id] = @id  AND af.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}


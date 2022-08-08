using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AmbsDataSyncs;

public class AmbsDataSyncQueryRepository : QueryRepositoryBase<AmbsDataSync>, IAmbsDataSyncQueryRepository
{
    public AmbsDataSyncQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<AmbsDataSync>> GetDataSyncList(Guid? countryId, DateTime? FromDate, DateTime? ToDate,int typeId,decimal conversionRate, int pageNumber,int pageSize)
    {
        //  var query = @"SELECT  x.[Id]
        //,x.[DataRequestQueueServiceId]
        //,x.[BranchCode]
        //,x.[BranchId]
        //,x.[BranchName]
        //,x.[Amount]
        //,x.[Amount]* "+conversionRate+ @" as AmountConverted 
        //,x.[IsActive]
        //,x.[FromDate]
        //,x.[ToDate]
        //,x.[CommonValueTableId]
        //,x.[CreatedBy]
        //,x.[CreatedOn]
        //,x.[UpdatedBy]
        //,x.[UpdatedOn]
        //,x.[ReviewedBy]
        //,x.[ReviewedOn]
        //,x.[ApprovedBy]
        //,x.[ApprovedOn]
        //,x.[IsDeleted],y.*,c.*,z.*,p.*,q.*
        //              FROM [security].[AmbsDataSync] x
        //              inner join [security].[DataRequestQueueService] y
        //              on x.DataRequestQueueServiceId=y.Id
        //              inner join [common].[Country] c
        //              on c.Id=y.CountryId
        //              inner join [BranchAudit].[RiskCriteria] z
        //              on z.CountryId=y.CountryId
        //              inner JOIN [Config].[CommonValueAndType] p
        //              on p.Id=z.RatingTypeId
        //              inner JOIN [Config].[CommonValueAndType] q
        //              on q.Id=z.RiskCriteriaTypeId
        //              where CommonValueTableId=@typeId
        //              and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
        //              and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
        //              and CAST(@FromDate as date)>=CAST(z.EffectiveFrom as DATE)
        //              and CAST(@ToDate as date)<=CAST(z.EffectiveTo as DATE)
        //              and x.[Amount] BETWEEN z.MinimumValue and z.MaximumValue
        //              and x.IsDeleted=0
        //           and y.CountryId=@CountryId";

        //        var query = @"declare @totalcount bigint	

        //SELECT  @totalcount=count(*)
        // FROM [security].[AmbsDataSync] x
        //                    inner join [security].[DataRequestQueueService] y
        //                    on x.DataRequestQueueServiceId=y.Id
        //                    inner join [common].[Country] c
        //                    on c.Id=y.CountryId
        //                    inner join [BranchAudit].[RiskCriteria] z
        //                    on z.CountryId=y.CountryId
        //                    inner JOIN [Config].[CommonValueAndType] p
        //                    on p.Id=z.RatingTypeId
        //                    inner JOIN [Config].[CommonValueAndType] q
        //                    on q.Id=z.RiskCriteriaTypeId
        //                    where CommonValueTableId=@typeId
        //                    and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
        //                    and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
        //                    and CAST(@FromDate as date)>=CAST(z.EffectiveFrom as DATE)
        //                    and CAST(@ToDate as date)<=CAST(z.EffectiveTo as DATE)
        //                    and x.[Amount] BETWEEN z.MinimumValue and z.MaximumValue
        //                    and x.IsDeleted=0
        //                 and y.CountryId=@CountryId
        //SELECT  x.[Id]
        //      ,x.[DataRequestQueueServiceId]
        //      ,x.[BranchCode]
        //      ,x.[BranchId]
        //      ,x.[BranchName]
        //      ,x.[Amount]
        //      ,x.[Amount]* @conversionRate as AmountConverted 
        //      ,x.[IsActive]
        //      ,x.[FromDate]
        //      ,x.[ToDate]
        //      ,x.[CommonValueTableId]
        //      ,x.[CreatedBy]
        //      ,x.[CreatedOn]
        //      ,x.[UpdatedBy]
        //      ,x.[UpdatedOn]
        //      ,x.[ReviewedBy]
        //      ,x.[ReviewedOn]
        //      ,x.[ApprovedBy]
        //      ,x.[ApprovedOn]
        //      ,x.[IsDeleted],y.*,c.*,z.*,p.*,q.*,@totalcount as TC
        //                    FROM [security].[AmbsDataSync] x
        //                    inner join [security].[DataRequestQueueService] y
        //                    on x.DataRequestQueueServiceId=y.Id
        //                    inner join [common].[Country] c
        //                    on c.Id=y.CountryId
        //                    inner join [BranchAudit].[RiskCriteria] z
        //                    on z.CountryId=y.CountryId
        //                    inner JOIN [Config].[CommonValueAndType] p
        //                    on p.Id=z.RatingTypeId
        //                    inner JOIN [Config].[CommonValueAndType] q
        //                    on q.Id=z.RiskCriteriaTypeId
        //                    where CommonValueTableId=@typeId
        //                    and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
        //                    and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
        //                    and CAST(@FromDate as date)>=CAST(z.EffectiveFrom as DATE)
        //                    and CAST(@ToDate as date)<=CAST(z.EffectiveTo as DATE)
        //                    and x.[Amount] BETWEEN z.MinimumValue and z.MaximumValue
        //                    and x.IsDeleted=0
        //                 and y.CountryId=@CountryId
        //				 order by x.FromDate
        //				 OFFSET ((@pageNumber-1) * @pageSize) ROWS
        //				FETCH NEXT @pageSize ROWS ONLY;";

        var query = "EXEC [dbo].[GetAmbsDataSyncList] @typeId,@conversionRate,@FromDate,@ToDate,@CountryId,@pageNumber,@pageSize";
        var parameters = new Dictionary<string, object> { { "FromDate", FromDate }, { "ToDate", ToDate }, { "CountryId", countryId },{ "typeId",typeId },{ "conversionRate",conversionRate },{"pageNumber" ,pageNumber},{ "pageSize",pageSize} };

        string splitters = "Id, Id, Id, Id, Id, Id, TC";

        var data = await Get<AmbsDataSync, Domain.Entities.security.DataRequestQueueService,Country,RiskCriteria,CommonValueAndType,CommonValueAndType,EfTotalCount, AmbsDataSync>(query, (ambsdatasync, datarequestqueueservice,country,riskcriteria,rating,criteria,eftotalcount) =>
        {
            AmbsDataSync doc;
            doc = ambsdatasync;
            doc.DataRequestQueueService = datarequestqueueservice;
            doc.DataRequestQueueService.Country = country;
            doc.RiskCriteria = riskcriteria;
            doc.RiskCriteria.CommonValueRatingType = rating;
            doc.RiskCriteria.CommonValueRiskCriteriaType = criteria;
            doc.TotalCount = eftotalcount;
            //doc.RiskCriteria.CommonValueRatingType = commonvaluerating;
            //doc.RiskCriteria.CommonValueRiskCriteriaType = commonvaluecriteria;
            //doc.DataRequestQueueService.Country = country;
            //doc.RiskCriteria = riskcriteria;
            //doc.RiskCriteria.CommonValueRatingType = commonvaluetype;
            //doc.RiskCriteria.CommonValueRatingType = commonvaluecriteriatype;
            //doc.DocumentSource = documentsource;

            return doc;
        }, parameters, splitters, false);
        return data.Distinct();
    }

   
}

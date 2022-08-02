using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
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

    public async Task<IEnumerable<AmbsDataSync>> GetDataSyncList(Guid? countryId, DateTime? FromDate, DateTime? ToDate,int typeId,decimal conversionRate)
    {
        var query = @"SELECT  x.[Id]
      ,x.[DataRequestQueueServiceId]
      ,x.[BranchCode]
      ,x.[BranchId]
      ,x.[BranchName]
      ,x.[Amount]
      ,x.[Amount]* "+conversionRate+@" as AmountConverted 
      ,x.[IsActive]
      ,x.[FromDate]
      ,x.[ToDate]
      ,x.[CommonValueTableId]
      ,x.[CreatedBy]
      ,x.[CreatedOn]
      ,x.[UpdatedBy]
      ,x.[UpdatedOn]
      ,x.[ReviewedBy]
      ,x.[ReviewedOn]
      ,x.[ApprovedBy]
      ,x.[ApprovedOn]
      ,x.[IsDeleted],y.*,c.*,z.*,p.*,q.*
                    FROM [security].[AmbsDataSync] x
                    inner join [security].[DataRequestQueueService] y
                    on x.DataRequestQueueServiceId=y.Id
                    inner join [common].[Country] c
                    on c.Id=y.CountryId
                    inner join [BranchAudit].[RiskCriteria] z
                    on z.CountryId=y.CountryId
                    inner JOIN [Config].[CommonValueAndType] p
                    on p.Id=z.RatingTypeId
                    inner JOIN [Config].[CommonValueAndType] q
                    on q.Id=z.RiskCriteriaTypeId
                    where CommonValueTableId=@typeId
                    and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
                    and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
                    and x.IsDeleted=0
                    and y.CountryId=@CountryId";
        var parameters = new Dictionary<string, object> { { "FromDate", FromDate }, { "ToDate", ToDate }, { "CountryId", countryId },{ "typeId",typeId } };

        string splitters = "Id, Id, Id, Id, Id, Id";

        var data = await Get<AmbsDataSync, Domain.Entities.security.DataRequestQueueService,Country,RiskCriteria,CommonValueAndType,CommonValueAndType, AmbsDataSync>(query, (ambsdatasync, datarequestqueueservice,country,riskcriteria,rating,criteria) =>
        {
            AmbsDataSync doc;
            doc = ambsdatasync;
            doc.DataRequestQueueService = datarequestqueueservice;
            doc.DataRequestQueueService.Country = country;
            doc.RiskCriteria = riskcriteria;
            doc.RiskCriteria.CommonValueRatingType = rating;
            doc.RiskCriteria.CommonValueRiskCriteriaType = criteria;
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

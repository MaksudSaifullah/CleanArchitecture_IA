using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ModuleFeature;

public class ModuleFeatureQueryRepository : QueryRepositoryBase<Domain.Entities.Common.ModuleFeature>, IModuleFeatureQueryRepository
{
    public ModuleFeatureQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<Domain.Entities.Common.ModuleFeature>> GetAllModuleFeatureList(Guid featureId)
    {
        var totalQuery = @"
					declare @totalcount bigint					
					select @totalcount=count(*) from [common].[ModuleFeature] modulefeature
                    inner join [common].[AuditFeature] auditfeature
                    on modulefeature.FeatureId=auditfeature.Id
                    inner join [common].[AuditModule] auditmodule
                    on modulefeature.ModuleId=auditmodule.Id
                    where modulefeature.IsDeleted=0 and auditfeature.IsDeleted=0
                    and auditmodule.IsDeleted=0 ";
        if (featureId != Guid.Empty)
        {
            totalQuery += " and auditmodule.Id='" + featureId + "' ";
        }



        var query = totalQuery+ @" 	select x.Id,x.ModuleId,x.FeatureId,x.CreatedBy,x.CreatedOn,x.UpdatedBy,x.UpdatedOn,x.ReviewedBy,x.ReviewedOn,x.ApprovedBy,x.ApprovedOn,x.IsDeleted,case when x.POST>x.PRE then x.POST 
					when  x.POST=x.PRE then 1
					else -1 end as RowSpan
					,x.auditfeatureid as Id
					,x.auditfeatureName as [Name]
					,x.auditfeatureDisplayName as [DisplayName]
					,x.auditfeatureIsActive as [IsActive]
					,x.auditfeatureCreatedBy as [CreatedBy]
					,x.auditfeatureCreatedOn as [CreatedOn]
					,x.auditfeatureUpdatedBy as [UpdatedBy]
					,x.auditfeatureUpdatedOn as [UpdatedOn]
					,x.auditfeatureReviewedBy as [ReviewedBy]
					,x.auditfeatureReviewedOn as [ReviewedOn]					
					,x.auditfeatureApprovedBy as [ApprovedBy]
					,x.auditfeatureApprovedOn as [ApprovedOn]
					,x.auditfeatureIsDeleted as [IsDeleted]
					,x.auditmoduleid as Id
					,x.auditmoduleName as [Name]
					,x.auditmoduleDisplayName as [DisplayName]
					,x.auditmoduleIsActive as [IsActive]
					,x.auditmoduleCreatedBy as [CreatedBy]
					,x.auditmoduleCreatedOn as [CreatedOn]
					,x.auditmoduleUpdatedBy as [UpdatedBy]
					,x.auditmoduleUpdatedOn as [UpdatedOn]
					,x.auditmoduleReviewedBy as [ReviewedBy]
					,x.auditmoduleReviewedOn as [ReviewedOn]					
					,x.auditmoduleApprovedBy as [ApprovedBy]
					,x.auditmoduleApprovedOn as [ApprovedOn]
					,x.auditmoduleIsDeleted as [IsDeleted]
					,@totalcount as Tc
					from(
						select *,isnull(lag(RN)over (partition by x.auditmoduleid order by auditmoduleid),0)PRE ,isnull(lead(RN)over (partition by x.auditmoduleid order by auditmoduleid),0)POST  from(
						SELECT modulefeature.*,ROW_NUMBER()over(partition by auditmodule.id order by auditmodule.id)RN
					,auditfeature.[Id]			auditfeatureid
					,auditfeature.[Name]		auditfeatureName
					,auditfeature.[DisplayName]	auditfeatureDisplayName
					,auditfeature.[IsActive]    auditfeatureIsActive   
					,auditfeature.[CreatedBy]	auditfeatureCreatedBy 
					,auditfeature.[CreatedOn]	auditfeatureCreatedOn 
					,auditfeature.[UpdatedBy]	auditfeatureUpdatedBy 
					,auditfeature.[UpdatedOn]	auditfeatureUpdatedOn 
					,auditfeature.[ReviewedBy]	auditfeatureReviewedBy 
					,auditfeature.[ReviewedOn]	auditfeatureReviewedOn 
					,auditfeature.[ApprovedBy]	auditfeatureApprovedBy 
					,auditfeature.[ApprovedOn]	auditfeatureApprovedOn 
					,auditfeature.[IsDeleted]	auditfeatureIsDeleted
					,auditmodule.[Id]			auditmoduleid
					,auditmodule.[Name]			auditmoduleName
					,auditmodule.[DisplayName]  auditmoduleDisplayName
					,auditmodule.[IsActive]		auditmoduleIsActive
					,auditmodule.[CreatedBy]	auditmoduleCreatedBy
					,auditmodule.[CreatedOn]	auditmoduleCreatedOn
					,auditmodule.[UpdatedBy]	auditmoduleUpdatedBy
					,auditmodule.[UpdatedOn]	auditmoduleUpdatedOn
					,auditmodule.[ReviewedBy]	auditmoduleReviewedBy
					,auditmodule.[ReviewedOn]	auditmoduleReviewedOn
					,auditmodule.[ApprovedBy]	auditmoduleApprovedBy
					,auditmodule.[ApprovedOn]	auditmoduleApprovedOn
					,auditmodule.[IsDeleted]	auditmoduleIsDeleted
					FROM [common].[ModuleFeature] modulefeature
                    inner join [common].[AuditFeature] auditfeature
                    on modulefeature.FeatureId=auditfeature.Id
                    inner join [common].[AuditModule] auditmodule
                    on modulefeature.ModuleId=auditmodule.Id
                    where modulefeature.IsDeleted=0 and auditfeature.IsDeleted=0
                    and auditmodule.IsDeleted=0
					)x
					)x
";
        if(featureId != Guid.Empty)
        {
            query += " and auditmodule.Id='" + featureId+"'";
        }



        string splitters = "Id, Id, Tc";
        var parameters = new Dictionary<string, object> { };
        var moduleDictionary = new Dictionary<Guid, Domain.Entities.Common.ModuleFeature>();
        var data = await Get<Domain.Entities.Common.ModuleFeature, AuditFeature, AuditModule, EfTotalCount, Domain.Entities.Common.ModuleFeature>(query, (modulefeature, auditfeature, auditmodule,eftotalcount) =>
        {

            Domain.Entities.Common.ModuleFeature modulefeaturelist;
            modulefeaturelist = modulefeature;
            modulefeaturelist.Feature = auditfeature;
            modulefeaturelist.Module=auditmodule;
            modulefeaturelist.TotalCount = eftotalcount;

            return modulefeaturelist;
        }, parameters, splitters, false);
        return data.Distinct();
    }

    public async Task<IEnumerable<AuditModule>> GetOnlyModuleList()
    {
        var query = @"SELECT [Id]
                    ,[Name]
                    ,[DisplayName]      
                     FROM [common].[AuditModule]
                     where IsDeleted=0";        

        return (IEnumerable<AuditModule>)await Get(query);
    }
}

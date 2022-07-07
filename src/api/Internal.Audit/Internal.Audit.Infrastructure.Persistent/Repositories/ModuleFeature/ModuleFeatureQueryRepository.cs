using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
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
        var query = @"SELECT *
                    FROM [common].[ModuleFeature] modulefeature
                    inner join [common].[AuditFeature] auditfeature
                    on modulefeature.FeatureId=auditfeature.Id
                    inner join [common].[AuditModule] auditmodule
                    on modulefeature.ModuleId=auditmodule.Id
                    where modulefeature.IsDeleted=0 and auditfeature.IsDeleted=0
                    and auditmodule.IsDeleted=0";
        if(featureId != Guid.Empty)
        {
            query += " and modulefeature.FeatureId='" + featureId+"'";
        }
        string splitters = "Id, Id";
        var parameters = new Dictionary<string, object> { };
        var moduleDictionary = new Dictionary<Guid, Domain.Entities.Common.ModuleFeature>();
        var data = await Get<Domain.Entities.Common.ModuleFeature, Domain.Entities.Common.AuditFeature, Domain.Entities.Common.AuditModule, Domain.Entities.Common.ModuleFeature>(query, (modulefeature, auditfeature, auditmodule) =>
        {

            Domain.Entities.Common.ModuleFeature modulefeaturelist;
            modulefeaturelist = modulefeature;
            modulefeaturelist.Feature = auditfeature;
            modulefeaturelist.Module=auditmodule;           

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

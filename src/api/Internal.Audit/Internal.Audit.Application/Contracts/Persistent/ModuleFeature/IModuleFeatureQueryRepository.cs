﻿namespace Internal.Audit.Application.Contracts.Persistent.ModuleFeature;

public interface IModuleFeatureQueryRepository : IAsyncQueryRepository<Domain.Entities.Common.ModuleFeature>
{
    Task<IEnumerable<Domain.Entities.Common.ModuleFeature>> GetAllModuleFeatureList(Guid FeatureId);
    Task<IEnumerable<Domain.Entities.Common.AuditModule>> GetOnlyModuleList();

}


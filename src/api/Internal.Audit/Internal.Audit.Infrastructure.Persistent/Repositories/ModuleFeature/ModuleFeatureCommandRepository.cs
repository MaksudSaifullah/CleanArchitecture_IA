using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ModuleFeature;

public class ModuleFeatureCommandRepository : CommandRepositoryBase<Domain.Entities.Common.ModuleFeature>, IModuleFeatureCommandRepository
{
    public ModuleFeatureCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.ModuleFeature;

public interface IModuleFeatureCommandRepository : IAsyncCommandRepository<Domain.Entities.Common.ModuleFeature>
{
}

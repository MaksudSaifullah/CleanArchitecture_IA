using Internal.Audit.Application.Contracts.Persistent.WeightScoreConfigurations;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.WeightScoreConfigurations;

    public class WeightScoreConfigurationCommandRepository : CommandRepositoryBase<WeightScore>, IWeightScoreConfigurationCommandRepository
    {
        public WeightScoreConfigurationCommandRepository(InternalAuditContext context) : base(context)
        {
        }
    }


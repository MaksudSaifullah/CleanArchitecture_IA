using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.WeightScoreConfigurations;

public interface IWeightScoreConfigurationQueryRepository : IAsyncQueryRepository<WeightScore>
{
    //Task<(long, IEnumerable<CompositeRiskProfile>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null);
    Task<WeightScore> GetByCountryId(Guid countryId);
}


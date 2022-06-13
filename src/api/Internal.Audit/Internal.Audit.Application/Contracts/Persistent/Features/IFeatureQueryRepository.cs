using Internal.Audit.Domain.Entities.Common;

namespace Internal.Audit.Application.Contracts.Persistent.Features;

public interface IFeatureQueryRepository : IAsyncQueryRepository<Feature>
{
    Task<IEnumerable<Feature>> GetAll();
    //Task<Module> GetById(Guid id);
}

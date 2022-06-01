using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Designations;


public class DesignationCommandRepository : CommandRepositoryBase<Designation>, IDesignationCommandRepository
{
    public DesignationCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}
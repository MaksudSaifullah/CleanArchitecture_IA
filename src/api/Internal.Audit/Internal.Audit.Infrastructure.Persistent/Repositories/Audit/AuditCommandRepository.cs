using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Audit
{
    public class AuditCommandRepository : CommandRepositoryBase<AuditCreation>, IAuditCommandRepository
    {
        public AuditCommandRepository(InternalAuditContext context) : base(context)
        {

        }
    }
}

using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditFrequencies;

public class AuditFrequencyCommandRepository : CommandRepositoryBase<AuditFrequency>, IAuditFrequencyCommandRepository
{
    public AuditFrequencyCommandRepository(InternalAuditContext context) : base(context)
    {
    }

}
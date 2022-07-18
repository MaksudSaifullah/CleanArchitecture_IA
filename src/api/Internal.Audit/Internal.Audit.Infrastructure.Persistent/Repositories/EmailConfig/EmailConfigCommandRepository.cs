using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.EmailConfig
{
    public class EmailConfigCommandRepository : CommandRepositoryBase<EmailConfiguration>, IEmailConfigCommandRepository
    {
        public EmailConfigCommandRepository(InternalAuditContext context) : base(context)
        {

        }
    }
}

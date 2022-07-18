using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.config;

namespace Internal.Audit.Application.Contracts.Persistent.EmailConfigs
{
    public interface IEmailConfigCommandRepository : IAsyncCommandRepository<EmailConfiguration>
    {
    }
}

using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Designations;
public interface IDesignationCommandRepository: IAsyncCommandRepository<Designation>
{
}

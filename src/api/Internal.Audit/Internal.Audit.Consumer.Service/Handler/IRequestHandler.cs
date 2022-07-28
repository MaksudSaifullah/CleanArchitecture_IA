using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Handler
{
    public interface IRequestHandler
    {
        Task<bool> ProcessRequest(DateTime startDate, DateTime endDate,Guid DataRequestQueueServiceId);
    }
}

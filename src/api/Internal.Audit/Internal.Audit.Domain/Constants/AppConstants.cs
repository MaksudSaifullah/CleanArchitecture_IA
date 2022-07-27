using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Constants
{
    public class AppConstants
    {
        public enum RequestStatus
        {
            REQUESTED = 1,
            PROCESSING = 2,
            PROCESSED = 3,
            ERROR = -1
        }
    }
}

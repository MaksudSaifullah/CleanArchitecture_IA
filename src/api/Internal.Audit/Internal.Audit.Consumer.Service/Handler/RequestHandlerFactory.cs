using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Consumer.Service.Handler
{
    public class RequestHandlerFactory
    {
        public RequestHandlerFactory()
        {
        }

        public IRequestHandler GetRequestHandler(bool compareOnly)
        {
            switch (compareOnly)
            {
                case true: return new CompareRequestHandler();
                default: return new RequestHandler();
            }
        }
    }
}

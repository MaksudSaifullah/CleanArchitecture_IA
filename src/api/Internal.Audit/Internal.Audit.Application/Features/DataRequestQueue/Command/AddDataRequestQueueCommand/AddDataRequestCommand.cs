using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;

public class AddDatarequestCommand:IRequest<AddDataRequestCommandDTO>
{
    public Guid CountryId { get; set; }
    public string RequestType { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

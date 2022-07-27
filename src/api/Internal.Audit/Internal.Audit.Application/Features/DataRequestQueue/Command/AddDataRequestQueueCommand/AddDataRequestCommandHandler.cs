using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;

public class AddDataRequestCommandHandler : IRequestHandler<AddDatarequestCommand, AddDataRequestCommandDTO>
{
    public Task<AddDataRequestCommandDTO> Handle(AddDatarequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

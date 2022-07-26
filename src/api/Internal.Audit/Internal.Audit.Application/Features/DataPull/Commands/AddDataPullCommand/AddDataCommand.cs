using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DataPull.Commands.AddDataPullCommand;

public class AddDataCommand:IRequest<AddDataPullCommandDTO>
{
    public Guid? Id { get; set; }
    public string Country { get; set; }
}

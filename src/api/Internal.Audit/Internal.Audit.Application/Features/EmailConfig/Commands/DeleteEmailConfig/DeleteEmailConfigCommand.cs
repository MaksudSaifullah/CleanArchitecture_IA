using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Commands.DeleteEmailConfig;
public class DeleteEmailConfigCommand : IRequest<DeleteEmailConfigResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteEmailConfigCommand(Guid id)
    {
        Id = id;
    }
}
